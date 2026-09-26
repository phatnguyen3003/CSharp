# 📝 Trình Soạn Thảo & Xuất Báo Cáo Thực Hành C# (Word .DOCX)

Ứng dụng giao diện đồ họa (GUI) viết bằng Python cho phép tạo, quản lý và xuất các báo cáo thực hành môn Lập trình C# ra định dạng Microsoft Word (`.docx`) theo chuẩn thiết kế bài học chuyên nghiệp.

---

## 🌟 Tính Năng Nổi Bật

1. **Quản lý đa bài tập**: Thêm, sửa, xóa, nhân bản, sắp xếp thứ tự (Lên/Xuống) các bài tập.
2. **Cấu trúc chuẩn 5 phần cho mỗi bài**:
   - 📌 **1. Đề bài**: Khung viền màu xanh lam, căn lề và định dạng trang trọng.
   - 📊 **2. Sơ đồ lớp (Class Diagram)**:
     - Cho phép chọn file ảnh sơ đồ lớp (`.png`, `.jpg`, `.jpeg`, `.bmp`).
     - **Tùy chọn (Optional)**: Nếu chưa có ảnh, hệ thống tự động để **khung viền nét đứt placeholder** để bạn chèn ảnh vào file Word sau.
   - 💻 **3. Mã nguồn C# (Source Code)**:
     - Nạp trực tiếp 1 hoặc nhiều file `.cs` từ máy tính (tự động đọc nội dung).
     - Hoặc nhập / dán code thủ công trực tiếp trên giao diện.
     - Định dạng font `Consolas`, nền xám nhạt với thanh viền xanh VS Code.
   - 🖥️ **4. Kết quả chạy thử (Test Run / Output)**:
     - Khung Terminal nền tối (Dark mode), chữ xanh lá sáng (`#00FF66`).
   - 💡 **5. Ý tưởng bài làm & Thiết kế giải pháp**:
     - Khung viền xanh lá trang nhã để ghi nhận phân tích OOP (tính bao gói, kế thừa, đa hình, giải thuật).
3. **Quản lý dự án**: Lưu lại toàn bộ dữ liệu đang soạn ra file `.json` và mở lại bất cứ lúc nào mà không sợ mất dữ liệu.
4. **Nạp sẵn mẫu Tuần 2**: Nút **⚡ Nạp 18 Bài Mẫu Tuần 2** nạp ngay dữ liệu 18 bài tập thực hành vào giao diện.
5. **Xuất file DOCX tùy biến**: Cho phép đặt tên file và chọn vị trí lưu tùy ý.

---

## 🚀 Hướng Dẫn Cài Đặt & Chạy

### Cách 1: Chạy tự động (Khuyên dùng)
Chỉ cần nhấp đúp chuột vào file **`run.bat`**.
> File `run.bat` sẽ tự động tạo thư mục môi trường ảo `venv`, tải cài đặt các thư viện trong `requirements.txt` và khởi chạy giao diện.

### Cách 2: Chạy bằng dòng lệnh thủ công
```bash
# 1. Di chuyển vào thư mục
cd c:\Users\nguye\Desktop\CSharp\trinh_soan_bao_cao

# 2. Tạo môi trường ảo venv
python -m venv venv

# 3. Kích hoạt venv
# Trên Windows PowerShell:
.\venv\Scripts\Activate.ps1
# Hoặc trên CMD:
venv\Scripts\activate.bat

# 4. Cài đặt thư viện
pip install -r requirements.txt

# 5. Khởi chạy ứng dụng
python main.py
```

---

## 📁 Cấu Trúc Thư Mục

```
trinh_soan_bao_cao/
│
├── app.py               # Giao diện đồ họa chính (Tkinter GUI)
├── main.py              # Điểm khởi chạy ứng dụng
├── models.py            # Quản lý cấu trúc dữ liệu ReportProject, Exercise, CodeFile
├── docx_generator.py    # Module xuất tài liệu Word (.docx) chuẩn OpenXML
├── requirements.txt     # Danh sách thư viện phụ thuộc
├── run.bat              # Script tự động tạo venv và khởi chạy
└── README.md            # Tài liệu hướng dẫn sử dụng
```
