import os
import sys
import tkinter as tk
from tkinter import ttk, filedialog, messagebox
from typing import Optional

from models import ReportProject, Exercise, CodeFile
from docx_generator import generate_report_docx


class ReportComposerApp:
    def __init__(self, root: tk.Tk):
        self.root = root
        self.root.title("Trình Soạn Thảo Báo Cáo Thực Hành C# (Xuất File DOCX)")
        self.root.geometry("1240x840")
        self.root.minsize(1050, 700)

        # Application state
        self.project = ReportProject()
        self.current_exercise_idx: Optional[int] = None
        self.current_code_file_idx: Optional[int] = None
        self.is_updating_ui = False

        # Setup modern styles
        self._setup_styles()

        # Build UI layout
        self._build_layout()

        # Start with default 1 blank exercise
        self._init_default_data()

    def _setup_styles(self):
        style = ttk.Style()
        style.theme_use('clam')

        # Colors
        bg_main = "#F3F4F6"
        accent_blue = "#1B365D"
        accent_green = "#2E7D32"

        self.root.configure(bg=bg_main)
        style.configure(".", background=bg_main, font=("Segoe UI", 10))
        style.configure("TFrame", background=bg_main)
        style.configure("TLabelframe", background=bg_main, font=("Segoe UI", 10, "bold"))
        style.configure("TLabelframe.Label", background=bg_main, foreground="#1B365D", font=("Segoe UI", 10, "bold"))

        # Buttons
        style.configure("Accent.TButton", background="#007ACC", foreground="white", font=("Segoe UI", 10, "bold"), padding=6)
        style.map("Accent.TButton", background=[("active", "#005999"), ("pressed", "#004477")])

        style.configure("Success.TButton", background="#2E7D32", foreground="white", font=("Segoe UI", 10, "bold"), padding=6)
        style.map("Success.TButton", background=[("active", "#1B5E20"), ("pressed", "#0D3813")])

        style.configure("Danger.TButton", background="#D32F2F", foreground="white", font=("Segoe UI", 9), padding=4)
        style.map("Danger.TButton", background=[("active", "#B71C1C")])

        style.configure("Sidebar.TButton", font=("Segoe UI", 9), padding=5)

    def _build_layout(self):
        # Main Paned Window
        main_paned = ttk.PanedWindow(self.root, orient=tk.HORIZONTAL)
        main_paned.pack(fill=tk.BOTH, expand=True, padx=8, pady=8)

        # ----------------- SIDEBAR (LEFT) -----------------
        sidebar_frame = ttk.Frame(main_paned, width=310)
        main_paned.add(sidebar_frame, weight=1)

        # Sidebar Title
        sb_title = tk.Label(sidebar_frame, text="📚 DANH SÁCH BÀI TẬP", font=("Segoe UI", 11, "bold"), bg="#1B365D", fg="white", pady=8)
        sb_title.pack(fill=tk.X, pady=(0, 6))

        # Exercise Listbox with Scrollbar
        list_frame = ttk.Frame(sidebar_frame)
        list_frame.pack(fill=tk.BOTH, expand=True, pady=4)

        sb_scroll = ttk.Scrollbar(list_frame, orient=tk.VERTICAL)
        self.ex_listbox = tk.Listbox(
            list_frame,
            yscrollcommand=sb_scroll.set,
            font=("Segoe UI", 10),
            selectmode=tk.SINGLE,
            activestyle="none",
            bg="white",
            selectbackground="#007ACC",
            selectforeground="white",
            relief=tk.SOLID,
            bd=1
        )
        sb_scroll.config(command=self.ex_listbox.yview)
        self.ex_listbox.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        sb_scroll.pack(side=tk.RIGHT, fill=tk.Y)
        self.ex_listbox.bind("<<ListboxSelect>>", self._on_select_exercise)

        # Exercise List Operations
        btn_grid1 = ttk.Frame(sidebar_frame)
        btn_grid1.pack(fill=tk.X, pady=4)

        ttk.Button(btn_grid1, text="➕ Thêm bài", style="Accent.TButton", command=self._add_exercise).pack(side=tk.LEFT, fill=tk.X, expand=True, padx=2)
        ttk.Button(btn_grid1, text="❌ Xóa bài", style="Danger.TButton", command=self._delete_exercise).pack(side=tk.LEFT, fill=tk.X, expand=True, padx=2)

        btn_grid2 = ttk.Frame(sidebar_frame)
        btn_grid2.pack(fill=tk.X, pady=2)
        ttk.Button(btn_grid2, text="⬆ Lên", style="Sidebar.TButton", command=self._move_up_exercise).pack(side=tk.LEFT, fill=tk.X, expand=True, padx=2)
        ttk.Button(btn_grid2, text="⬇ Xuống", style="Sidebar.TButton", command=self._move_down_exercise).pack(side=tk.LEFT, fill=tk.X, expand=True, padx=2)
        ttk.Button(btn_grid2, text="📋 Nhân bản", style="Sidebar.TButton", command=self._duplicate_exercise).pack(side=tk.LEFT, fill=tk.X, expand=True, padx=2)

        # Separator
        ttk.Separator(sidebar_frame, orient=tk.HORIZONTAL).pack(fill=tk.X, pady=8)

        # Project File Ops
        ttk.Button(sidebar_frame, text="📂 Mở Dự Án (.json)", style="Sidebar.TButton", command=self._open_project).pack(fill=tk.X, pady=3)
        ttk.Button(sidebar_frame, text="💾 Lưu Dự Án (.json)", style="Sidebar.TButton", command=self._save_project).pack(fill=tk.X, pady=3)
        ttk.Button(sidebar_frame, text="⚡ Nạp 18 Bài Mẫu Tuần 2", style="Sidebar.TButton", command=self._load_sample_tuan2).pack(fill=tk.X, pady=3)

        ttk.Separator(sidebar_frame, orient=tk.HORIZONTAL).pack(fill=tk.X, pady=8)

        # EXPORT DOCX BUTTON
        ttk.Button(
            sidebar_frame,
            text="🚀 XUẤT BÁO CÁO (.DOCX)",
            style="Success.TButton",
            command=self._export_docx
        ).pack(fill=tk.X, pady=6)

        # ----------------- MAIN CONTENT (RIGHT) -----------------
        content_frame = ttk.Frame(main_paned)
        main_paned.add(content_frame, weight=3)

        # Notebook (Tabs)
        self.notebook = ttk.Notebook(content_frame)
        self.notebook.pack(fill=tk.BOTH, expand=True)

        # Tab 1: Chi tiết bài tập
        self.tab_exercise = ttk.Frame(self.notebook)
        self.notebook.add(self.tab_exercise, text="📝 Chi Tiết Bài Tập")

        # Tab 2: Thông tin chung báo cáo
        self.tab_general = ttk.Frame(self.notebook)
        self.notebook.add(self.tab_general, text="⚙️ Cài Đặt Chung Báo Cáo")

        self._build_general_tab()
        self._build_exercise_tab()

        # Status bar at bottom
        self.status_var = tk.StringVar(value="Sẵn sàng.")
        status_bar = tk.Label(self.root, textvariable=self.status_var, relief=tk.SUNKEN, anchor=tk.W, font=("Segoe UI", 9), bg="#E5E7EB", fg="#374151", padx=8, pady=3)
        status_bar.pack(side=tk.BOTTOM, fill=tk.X)

    # ----------------- GENERAL TAB -----------------
    def _build_general_tab(self):
        pad = 12
        frame = ttk.Frame(self.tab_general, padding=pad)
        frame.pack(fill=tk.BOTH, expand=True)

        tk.Label(frame, text="Thông Tin Bìa / Đầu Báo Cáo", font=("Segoe UI", 12, "bold"), fg="#1B365D", bg="#F3F4F6").grid(row=0, column=0, columnspan=2, sticky=tk.W, pady=(0, 14))

        # Tiêu đề chính
        tk.Label(frame, text="Tiêu đề chính:", font=("Segoe UI", 10, "bold"), bg="#F3F4F6").grid(row=1, column=0, sticky=tk.W, pady=6)
        self.entry_main_title = ttk.Entry(frame, font=("Segoe UI", 10))
        self.entry_main_title.grid(row=1, column=1, sticky=tk.EW, pady=6)

        # Tiêu đề phụ
        tk.Label(frame, text="Tiêu đề phụ / Chủ đề:", font=("Segoe UI", 10, "bold"), bg="#F3F4F6").grid(row=2, column=0, sticky=tk.W, pady=6)
        self.entry_sub_title = ttk.Entry(frame, font=("Segoe UI", 10))
        self.entry_sub_title.grid(row=2, column=1, sticky=tk.EW, pady=6)

        # Môn học
        tk.Label(frame, text="Môn học:", font=("Segoe UI", 10, "bold"), bg="#F3F4F6").grid(row=3, column=0, sticky=tk.W, pady=6)
        self.entry_subject = ttk.Entry(frame, font=("Segoe UI", 10))
        self.entry_subject.grid(row=3, column=1, sticky=tk.EW, pady=6)

        # Người thực hiện
        tk.Label(frame, text="Người thực hiện (MSSV - Họ tên):", font=("Segoe UI", 10, "bold"), bg="#F3F4F6").grid(row=4, column=0, sticky=tk.W, pady=6)
        self.entry_author = ttk.Entry(frame, font=("Segoe UI", 10))
        self.entry_author.grid(row=4, column=1, sticky=tk.EW, pady=6)

        # Mô tả nội dung
        tk.Label(frame, text="Mô tả tóm tắt nội dung:", font=("Segoe UI", 10, "bold"), bg="#F3F4F6").grid(row=5, column=0, sticky=tk.NW, pady=6)
        self.text_topic_desc = tk.Text(frame, font=("Segoe UI", 10), height=5, wrap=tk.WORD, relief=tk.SOLID, bd=1)
        self.text_topic_desc.grid(row=5, column=1, sticky=tk.EW, pady=6)

        frame.columnconfigure(1, weight=1)

    # ----------------- EXERCISE TAB -----------------
    def _build_exercise_tab(self):
        # Scrollable canvas for exercise form
        canvas = tk.Canvas(self.tab_exercise, bg="#F3F4F6", highlightthickness=0)
        scrollbar = ttk.Scrollbar(self.tab_exercise, orient=tk.VERTICAL, command=canvas.yview)
        self.scrollable_form = ttk.Frame(canvas, padding=10)

        self.scrollable_form.bind(
            "<Configure>",
            lambda e: canvas.configure(scrollregion=canvas.bbox("all"))
        )

        canvas_frame = canvas.create_window((0, 0), window=self.scrollable_form, anchor="nw")
        canvas.configure(yscrollcommand=scrollbar.set)

        # Adjust width on window resize
        def on_canvas_configure(event):
            canvas.itemconfig(canvas_frame, width=event.width)
        canvas.bind("<Configure>", on_canvas_configure)

        canvas.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        scrollbar.pack(side=tk.RIGHT, fill=tk.Y)

        f = self.scrollable_form

        # --- EXERCISE HEADER (Title & Folder) ---
        header_box = ttk.LabelFrame(f, text="📌 Thông Tin Bài Tập", padding=8)
        header_box.pack(fill=tk.X, pady=(0, 8))

        row1 = ttk.Frame(header_box)
        row1.pack(fill=tk.X, pady=3)
        tk.Label(row1, text="Tiêu đề bài:", font=("Segoe UI", 10, "bold"), bg="#F3F4F6").pack(side=tk.LEFT, padx=(0, 6))
        self.entry_ex_title = ttk.Entry(row1, font=("Segoe UI", 10))
        self.entry_ex_title.pack(side=tk.LEFT, fill=tk.X, expand=True, padx=(0, 16))

        tk.Label(row1, text="Thư mục / Mã bài:", font=("Segoe UI", 10, "bold"), bg="#F3F4F6").pack(side=tk.LEFT, padx=(0, 6))
        self.entry_ex_folder = ttk.Entry(row1, font=("Segoe UI", 10), width=18)
        self.entry_ex_folder.pack(side=tk.LEFT)

        # Bind changes
        self.entry_ex_title.bind("<KeyRelease>", self._on_title_changed)

        # --- 1. ĐỀ BÀI ---
        prob_box = ttk.LabelFrame(f, text="1. Đề Bài (Problem Statement)", padding=8)
        prob_box.pack(fill=tk.X, pady=6)

        self.text_problem = tk.Text(prob_box, font=("Segoe UI", 10), height=4, wrap=tk.WORD, relief=tk.SOLID, bd=1)
        self.text_problem.pack(fill=tk.BOTH, expand=True, pady=2)

        # --- 2. SƠ ĐỒ LỚP (CLASS DIAGRAM) ---
        diag_box = ttk.LabelFrame(f, text="2. Sơ Đồ Lớp (Class Diagram - Tùy Chọn)", padding=8)
        diag_box.pack(fill=tk.X, pady=6)

        diag_row = ttk.Frame(diag_box)
        diag_row.pack(fill=tk.X, pady=2)

        ttk.Button(diag_row, text="🖼️ Chọn file ảnh sơ đồ...", command=self._browse_diagram_image).pack(side=tk.LEFT, padx=(0, 8))
        ttk.Button(diag_row, text="❌ Xóa ảnh", command=self._clear_diagram_image).pack(side=tk.LEFT, padx=(0, 12))

        self.lbl_diagram_path = tk.Label(
            diag_row,
            text="[Chưa chọn ảnh - File DOCX sẽ tạo khung nét đứt để dán ảnh sau]",
            font=("Segoe UI", 9, "italic"),
            fg="#666666",
            bg="#F3F4F6"
        )
        self.lbl_diagram_path.pack(side=tk.LEFT, fill=tk.X, expand=True)

        # --- 3. MÃ NGUỒN C# ---
        code_box = ttk.LabelFrame(f, text="3. Mã Nguồn C# (Source Code)", padding=8)
        code_box.pack(fill=tk.X, pady=6)

        # Code toolbar
        code_tools = ttk.Frame(code_box)
        code_tools.pack(fill=tk.X, pady=2)

        ttk.Button(code_tools, text="📂 Thêm File .cs từ máy...", style="Accent.TButton", command=self._add_cs_file).pack(side=tk.LEFT, padx=(0, 6))
        ttk.Button(code_tools, text="➕ Tạo File Code Mới", command=self._create_new_code_file).pack(side=tk.LEFT, padx=(0, 6))
        ttk.Button(code_tools, text="❌ Xóa File Code", style="Danger.TButton", command=self._delete_code_file).pack(side=tk.LEFT, padx=(0, 12))

        tk.Label(code_tools, text="File đang chọn:", font=("Segoe UI", 9, "bold"), bg="#F3F4F6").pack(side=tk.LEFT, padx=(6, 4))
        self.code_files_combo = ttk.Combobox(code_tools, state="readonly", width=26)
        self.code_files_combo.pack(side=tk.LEFT, padx=4)
        self.code_files_combo.bind("<<ComboboxSelected>>", self._on_select_code_file)

        # Code Text Area
        self.text_code = tk.Text(
            code_box,
            font=("Consolas", 10),
            height=12,
            wrap=tk.NONE,
            relief=tk.SOLID,
            bd=1,
            bg="#FAFAFA",
            fg="#1E1E1E"
        )
        code_scroll_y = ttk.Scrollbar(code_box, orient=tk.VERTICAL, command=self.text_code.yview)
        code_scroll_x = ttk.Scrollbar(code_box, orient=tk.HORIZONTAL, command=self.text_code.xview)
        self.text_code.config(yscrollcommand=code_scroll_y.set, xscrollcommand=code_scroll_x.set)

        self.text_code.pack(fill=tk.BOTH, expand=True, pady=4)
        code_scroll_y.pack(side=tk.RIGHT, fill=tk.Y, before=self.text_code)
        code_scroll_x.pack(fill=tk.X)

        # --- 4. KẾT QUẢ CHẠY THỬ (OUTPUT) ---
        out_box = ttk.LabelFrame(f, text="4. Kết Quả Chạy Thử (Console Output)", padding=8)
        out_box.pack(fill=tk.X, pady=6)

        self.text_output = tk.Text(
            out_box,
            font=("Consolas", 10),
            height=6,
            wrap=tk.WORD,
            relief=tk.SOLID,
            bd=1,
            bg="#1E1E1E",
            fg="#00FF66",
            insertbackground="white"
        )
        self.text_output.pack(fill=tk.BOTH, expand=True, pady=2)

        # --- 5. Ý TƯỞNG BÀI LÀM / THIẾT KẾ GIẢI PHÁP ---
        idea_box = ttk.LabelFrame(f, text="5. Ý Tưởng Bài Làm & Thiết Kế Giải Pháp (Idea / OOP Design)", padding=8)
        idea_box.pack(fill=tk.X, pady=6)

        self.text_idea = tk.Text(
            idea_box,
            font=("Segoe UI", 10),
            height=6,
            wrap=tk.WORD,
            relief=tk.SOLID,
            bd=1,
            bg="#F9FFF9",
            fg="#1C3B1E"
        )
        self.text_idea.pack(fill=tk.BOTH, expand=True, pady=2)

    # ----------------- DATA MANAGEMENT -----------------
    def _init_default_data(self):
        self.project = ReportProject(
            main_title="BÁO CÁO THỰC HÀNH",
            sub_title="LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG TRONG C#",
            subject="Ngôn ngữ lập trình C# (NNLTCS)",
            author="",
            topic_desc="Thiết kế lớp cơ bản, nâng cao, Kế thừa và Đa hình"
        )
        self.project.exercises.append(Exercise(
            title="Bài 1.1: Tính tuổi 1 sinh viên",
            folder="bai1",
            problem="Viết chương trình nhập thông tin sinh viên (họ tên, năm sinh). Tính và xuất tuổi sinh viên này.",
            code_files=[CodeFile("bai1.cs", "// Code C# tai day\n")],
            output="Nhap Ho Ten: Nguyen Van A\nNhap nam sinh: 2004\nTuoi cua sinh vien nay la: 22",
            idea="• Thiết kế lớp HocSinh gồm các thuộc tính HoTen, NamSinh, phương thức Tinhtuoi()."
        ))
        self._refresh_all_ui()

    def _save_current_form_to_model(self):
        """Lưu toàn bộ dữ liệu đang hiển thị trên form vào đối tượng Exercise và General Project."""
        if self.is_updating_ui:
            return

        # Save General Info
        self.project.main_title = self.entry_main_title.get()
        self.project.sub_title = self.entry_sub_title.get()
        self.project.subject = self.entry_subject.get()
        self.project.author = self.entry_author.get()
        self.project.topic_desc = self.text_topic_desc.get("1.0", tk.END).strip()

        # Save Exercise Detail
        if self.current_exercise_idx is not None and 0 <= self.current_exercise_idx < len(self.project.exercises):
            ex = self.project.exercises[self.current_exercise_idx]
            ex.title = self.entry_ex_title.get().strip()
            ex.folder = self.entry_ex_folder.get().strip()
            ex.problem = self.text_problem.get("1.0", tk.END).strip()
            ex.output = self.text_output.get("1.0", tk.END).strip()
            ex.idea = self.text_idea.get("1.0", tk.END).strip()

            # Save currently active code file
            if ex.code_files and self.current_code_file_idx is not None and 0 <= self.current_code_file_idx < len(ex.code_files):
                ex.code_files[self.current_code_file_idx].content = self.text_code.get("1.0", tk.END)

    def _load_exercise_to_form(self, idx: int):
        """Hiển thị thông tin của exercise thứ idx lên form."""
        if idx < 0 or idx >= len(self.project.exercises):
            return

        self.is_updating_ui = True
        self.current_exercise_idx = idx
        ex = self.project.exercises[idx]

        # Header
        self.entry_ex_title.delete(0, tk.END)
        self.entry_ex_title.insert(0, ex.title)

        self.entry_ex_folder.delete(0, tk.END)
        self.entry_ex_folder.insert(0, ex.folder)

        # Problem
        self.text_problem.delete("1.0", tk.END)
        self.text_problem.insert("1.0", ex.problem)

        # Diagram image
        if ex.diagram_image_path and os.path.exists(ex.diagram_image_path):
            self.lbl_diagram_path.config(text=f"Đã chọn: {os.path.basename(ex.diagram_image_path)} ({ex.diagram_image_path})", fg="#008800")
        else:
            self.lbl_diagram_path.config(text="[Chưa chọn ảnh - File DOCX sẽ tạo khung nét đứt để dán ảnh sau]", fg="#666666")

        # Code files combo
        self._refresh_code_files_combo(ex)

        # Output
        self.text_output.delete("1.0", tk.END)
        self.text_output.insert("1.0", ex.output)

        # Idea
        self.text_idea.delete("1.0", tk.END)
        self.text_idea.insert("1.0", ex.idea)

        self.is_updating_ui = False

    def _refresh_code_files_combo(self, ex: Exercise):
        if not ex.code_files:
            # Create a default code file if empty
            ex.code_files.append(CodeFile("Program.cs", "// Code C# tai day\n"))

        values = [f"{i+1}. {cf.filename}" for i, cf in enumerate(ex.code_files)]
        self.code_files_combo['values'] = values
        
        self.current_code_file_idx = 0
        self.code_files_combo.current(0)
        self.text_code.delete("1.0", tk.END)
        self.text_code.insert("1.0", ex.code_files[0].content)

    def _on_select_code_file(self, event):
        self._save_current_form_to_model()
        sel_idx = self.code_files_combo.current()
        if sel_idx >= 0 and self.current_exercise_idx is not None:
            ex = self.project.exercises[self.current_exercise_idx]
            if 0 <= sel_idx < len(ex.code_files):
                self.current_code_file_idx = sel_idx
                self.is_updating_ui = True
                self.text_code.delete("1.0", tk.END)
                self.text_code.insert("1.0", ex.code_files[sel_idx].content)
                self.is_updating_ui = False

    def _refresh_all_ui(self):
        self.is_updating_ui = True

        # General Tab
        self.entry_main_title.delete(0, tk.END)
        self.entry_main_title.insert(0, self.project.main_title)

        self.entry_sub_title.delete(0, tk.END)
        self.entry_sub_title.insert(0, self.project.sub_title)

        self.entry_subject.delete(0, tk.END)
        self.entry_subject.insert(0, self.project.subject)

        self.entry_author.delete(0, tk.END)
        self.entry_author.insert(0, self.project.author)

        self.text_topic_desc.delete("1.0", tk.END)
        self.text_topic_desc.insert("1.0", self.project.topic_desc)

        # Listbox
        self.ex_listbox.delete(0, tk.END)
        for idx, ex in enumerate(self.project.exercises):
            display_title = f"{idx + 1}. {ex.title}" if ex.title else f"{idx + 1}. (Chưa đặt tên bài)"
            self.ex_listbox.insert(tk.END, display_title)

        self.is_updating_ui = False

        if self.project.exercises:
            target_idx = self.current_exercise_idx if (self.current_exercise_idx is not None and self.current_exercise_idx < len(self.project.exercises)) else 0
            self.ex_listbox.select_set(target_idx)
            self._load_exercise_to_form(target_idx)

    # ----------------- EVENT HANDLERS -----------------
    def _on_select_exercise(self, event):
        sel = self.ex_listbox.curselection()
        if sel:
            idx = sel[0]
            if idx != self.current_exercise_idx:
                self._save_current_form_to_model()
                self._load_exercise_to_form(idx)

    def _on_title_changed(self, event):
        if self.current_exercise_idx is not None and not self.is_updating_ui:
            new_title = self.entry_ex_title.get().strip()
            self.project.exercises[self.current_exercise_idx].title = new_title
            display_str = f"{self.current_exercise_idx + 1}. {new_title}" if new_title else f"{self.current_exercise_idx + 1}. (Chưa đặt tên bài)"
            self.ex_listbox.delete(self.current_exercise_idx)
            self.ex_listbox.insert(self.current_exercise_idx, display_str)
            self.ex_listbox.select_set(self.current_exercise_idx)

    def _add_exercise(self):
        self._save_current_form_to_model()
        new_num = len(self.project.exercises) + 1
        new_ex = Exercise(
            title=f"Bài tập {new_num}",
            folder=f"bai{new_num}",
            problem="Đề bài...",
            code_files=[CodeFile(f"bai{new_num}.cs", "// Code C#\n")],
            output="Kết quả chạy...",
            idea="Ý tưởng bài làm..."
        )
        self.project.exercises.append(new_ex)
        self.current_exercise_idx = len(self.project.exercises) - 1
        self._refresh_all_ui()
        self.status_var.set(f"Đã thêm bài tập {new_num}.")

    def _delete_exercise(self):
        if not self.project.exercises:
            return
        sel = self.ex_listbox.curselection()
        if not sel:
            return
        idx = sel[0]

        if messagebox.askyesno("Xác nhận", f"Bạn có chắc muốn xóa bài số {idx + 1} ({self.project.exercises[idx].title})?"):
            self.project.exercises.pop(idx)
            if self.current_exercise_idx >= len(self.project.exercises):
                self.current_exercise_idx = max(0, len(self.project.exercises) - 1)
            self._refresh_all_ui()
            self.status_var.set(f"Đã xóa bài số {idx + 1}.")

    def _move_up_exercise(self):
        if self.current_exercise_idx is None or self.current_exercise_idx <= 0:
            return
        self._save_current_form_to_model()
        idx = self.current_exercise_idx
        self.project.exercises[idx], self.project.exercises[idx - 1] = self.project.exercises[idx - 1], self.project.exercises[idx]
        self.current_exercise_idx = idx - 1
        self._refresh_all_ui()

    def _move_down_exercise(self):
        if self.current_exercise_idx is None or self.current_exercise_idx >= len(self.project.exercises) - 1:
            return
        self._save_current_form_to_model()
        idx = self.current_exercise_idx
        self.project.exercises[idx], self.project.exercises[idx + 1] = self.project.exercises[idx + 1], self.project.exercises[idx]
        self.current_exercise_idx = idx + 1
        self._refresh_all_ui()

    def _duplicate_exercise(self):
        if self.current_exercise_idx is None or not self.project.exercises:
            return
        self._save_current_form_to_model()
        src_ex = self.project.exercises[self.current_exercise_idx]
        copied_ex = Exercise.from_dict(src_ex.to_dict())
        copied_ex.title += " (Bản sao)"
        self.project.exercises.insert(self.current_exercise_idx + 1, copied_ex)
        self.current_exercise_idx += 1
        self._refresh_all_ui()
        self.status_var.set("Đã nhân bản bài tập.")

    # ----------------- DIAGRAM IMAGE -----------------
    def _browse_diagram_image(self):
        if self.current_exercise_idx is None:
            return
        filetypes = [
            ("Image files", "*.png;*.jpg;*.jpeg;*.bmp;*.gif"),
            ("All files", "*.*")
        ]
        chosen = filedialog.askopenfilename(title="Chọn ảnh sơ đồ lớp (Class Diagram)", filetypes=filetypes)
        if chosen:
            ex = self.project.exercises[self.current_exercise_idx]
            ex.diagram_image_path = chosen
            self.lbl_diagram_path.config(text=f"Đã chọn: {os.path.basename(chosen)} ({chosen})", fg="#008800")
            self.status_var.set(f"Đã chọn ảnh sơ đồ lớp: {os.path.basename(chosen)}")

    def _clear_diagram_image(self):
        if self.current_exercise_idx is None:
            return
        ex = self.project.exercises[self.current_exercise_idx]
        ex.diagram_image_path = ""
        self.lbl_diagram_path.config(text="[Chưa chọn ảnh - File DOCX sẽ tạo khung nét đứt để dán ảnh sau]", fg="#666666")
        self.status_var.set("Đã xóa ảnh sơ đồ lớp.")

    # ----------------- CODE FILES -----------------
    def _add_cs_file(self):
        if self.current_exercise_idx is None:
            return
        filetypes = [("C# Source Files", "*.cs"), ("All files", "*.*")]
        files = filedialog.askopenfilenames(title="Chọn một hoặc nhiều file C# (.cs)", filetypes=filetypes)
        if files:
            ex = self.project.exercises[self.current_exercise_idx]
            for fp in files:
                fname = os.path.basename(fp)
                try:
                    with open(fp, "r", encoding="utf-8", errors="replace") as f:
                        code_content = f.read()
                    ex.code_files.append(CodeFile(filename=fname, content=code_content, filepath=fp))
                except Exception as e:
                    messagebox.showerror("Lỗi", f"Không thể đọc file {fname}: {e}")

            self._refresh_code_files_combo(ex)
            self.code_files_combo.current(len(ex.code_files) - 1)
            self._on_select_code_file(None)
            self.status_var.set(f"Đã thêm {len(files)} file C# vào bài.")

    def _create_new_code_file(self):
        if self.current_exercise_idx is None:
            return
        ex = self.project.exercises[self.current_exercise_idx]
        new_name = f"File_{len(ex.code_files) + 1}.cs"
        ex.code_files.append(CodeFile(filename=new_name, content="// Code C#\n"))
        self._refresh_code_files_combo(ex)
        self.code_files_combo.current(len(ex.code_files) - 1)
        self._on_select_code_file(None)
        self.status_var.set(f"Đã tạo file code mới: {new_name}")

    def _delete_code_file(self):
        if self.current_exercise_idx is None:
            return
        ex = self.project.exercises[self.current_exercise_idx]
        if not ex.code_files:
            return
        sel_idx = self.code_files_combo.current()
        if sel_idx >= 0:
            deleted_name = ex.code_files[sel_idx].filename
            ex.code_files.pop(sel_idx)
            self._refresh_code_files_combo(ex)
            self.status_var.set(f"Đã xóa file: {deleted_name}")

    # ----------------- LOAD SAMPLE TUAN 2 -----------------
    def _load_sample_tuan2(self):
        if messagebox.askyesno("Nạp Dữ Liệu Mẫu", "Bạn có muốn nạp toàn bộ 18 bài tập thực hành Tuần 2 (đã đọc từ folder Tuan2) vào trình soạn thảo?"):
            try:
                # Load sample script from Tuan2 directory if available
                sample_py = r"c:\Users\nguye\Desktop\CSharp\Tuan2\generate_all_reports.py"
                if os.path.exists(sample_py):
                    # We can import sections_data or reconstruct
                    import importlib.util
                    spec = importlib.util.spec_from_file_location("generate_all_reports", sample_py)
                    mod = importlib.util.module_from_spec(spec)
                    spec.loader.exec_module(mod)
                    raw_sections = getattr(mod, "sections_data", [])
                    
                    self.project = ReportProject(
                        main_title="BÁO CÁO THỰC HÀNH 02",
                        sub_title="LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG TRONG C#",
                        subject="Ngôn ngữ lập trình C# (NNLTCS)",
                        author="Sinh Viên Thực Hiện",
                        topic_desc="Field, Constructor, Property, Method, Overloading, Indexer, Interface, Delegate & Event, Kế thừa và Đa hình"
                    )
                    self.project.exercises = []
                    for sec in raw_sections:
                        code_files = [CodeFile(filename=cf["filename"], content=cf["content"]) for cf in sec.get("code_files", [])]
                        ex = Exercise(
                            title=sec.get("title", ""),
                            folder=sec.get("folder", ""),
                            problem=sec.get("problem", ""),
                            code_files=code_files,
                            output=sec.get("output", ""),
                            idea=sec.get("idea", "")
                        )
                        self.project.exercises.append(ex)
                    
                    self.current_exercise_idx = 0
                    self._refresh_all_ui()
                    messagebox.showinfo("Thành công", f"Đã nạp thành công {len(self.project.exercises)} bài tập từ Tuần 2!")
                else:
                    messagebox.showwarning("Thông báo", "Không tìm thấy thư mục Tuan2 để nạp mẫu.")
            except Exception as e:
                messagebox.showerror("Lỗi", f"Không thể nạp mẫu Tuần 2: {e}")

    # ----------------- SAVE / OPEN PROJECT -----------------
    def _save_project(self):
        self._save_current_form_to_model()
        filepath = filedialog.asksaveasfilename(
            title="Lưu Dự Án Báo Cáo (.json)",
            defaultextension=".json",
            filetypes=[("JSON Project Files", "*.json"), ("All Files", "*.*")]
        )
        if filepath:
            try:
                self.project.save_json(filepath)
                self.status_var.set(f"Đã lưu dự án vào: {filepath}")
                messagebox.showinfo("Thành công", "Đã lưu dự án thành công!")
            except Exception as e:
                messagebox.showerror("Lỗi", f"Không thể lưu dự án: {e}")

    def _open_project(self):
        filepath = filedialog.askopenfilename(
            title="Mở Dự Án Báo Cáo (.json)",
            filetypes=[("JSON Project Files", "*.json"), ("All Files", "*.*")]
        )
        if filepath:
            try:
                self.project = ReportProject.load_json(filepath)
                self.current_exercise_idx = 0
                self._refresh_all_ui()
                self.status_var.set(f"Đã mở dự án từ: {filepath}")
                messagebox.showinfo("Thành công", f"Đã mở dự án với {len(self.project.exercises)} bài tập!")
            except Exception as e:
                messagebox.showerror("Lỗi", f"Không thể mở file dự án: {e}")

    # ----------------- EXPORT DOCX -----------------
    def _export_docx(self):
        self._save_current_form_to_model()

        if not self.project.exercises:
            messagebox.showwarning("Cảnh báo", "Dự án hiện chưa có bài tập nào để xuất báo cáo!")
            return

        default_filename = f"{self.project.main_title.replace(' ', '_')}_{self.project.sub_title.replace(' ', '_')}.docx"
        filepath = filedialog.asksaveasfilename(
            title="Chọn Nơi Lưu Báo Cáo DOCX",
            initialfile=default_filename,
            defaultextension=".docx",
            filetypes=[("Word Document (.docx)", "*.docx"), ("All Files", "*.*")]
        )

        if filepath:
            try:
                generate_report_docx(self.project, filepath)
                self.status_var.set(f"Đã xuất thành công: {filepath}")
                if messagebox.askyesno("Thành công", f"Đã xuất file Word báo cáo thành công!\n\nĐường dẫn: {filepath}\n\nBạn có muốn mở file này ngay không?"):
                    os.startfile(filepath)
            except Exception as e:
                messagebox.showerror("Lỗi xuất Word", f"Đã xảy ra lỗi khi tạo file Word: {e}")


def main():
    root = tk.Tk()
    app = ReportComposerApp(root)
    root.mainloop()


if __name__ == "__main__":
    main()
