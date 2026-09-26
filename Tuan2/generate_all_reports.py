import os
from docx_builder import build_docx

base_dir = r"c:\Users\nguye\Desktop\CSharp\Tuan2"

def read_file(filepath):
    if os.path.exists(filepath):
        with open(filepath, 'r', encoding='utf-8', errors='replace') as f:
            return f.read()
    return ""

sections_data = [
    # BÀI 1.1
    {
        "title": "Bài 1.1: Tính tuổi 1 sinh viên",
        "folder": "bai1",
        "problem": """Viết chương trình nhập thông tin sinh viên (họ tên, năm sinh). Tính và xuất tuổi sinh viên này.
Yêu cầu: Xây dựng lớp HocSinh có đầy đủ các thành phần: Field, Constructor, Property, Method.""",
        "code_files": [
            {
                "filename": "bai1.cs",
                "content": read_file(os.path.join(base_dir, "bai1", "bai1.cs"))
            }
        ],
        "output": """===================================
Nhap Ho Ten: Nguyen Van An
Nhap nam sinh: 2004
Tuoi cua sinh vien nay la: 22""",
        "idea": """• Thiết kế lớp HocSinh bao gồm:
  - Các thuộc tính (Property): HoTen (string), NamSinh (int) để lưu trữ thông tin sinh viên.
  - Hàm khởi tạo (Constructor): Nhận 2 tham số họ tên và năm sinh để khởi tạo giá trị cho đối tượng.
  - Phương thức nghiệp vụ (Method): Tinhtuoi() thực hiện tính toán tuổi bằng cách lấy năm hiện tại (DateTime.Now.Year) trừ đi năm sinh (NamSinh) và in kết quả ra màn hình.
  - Phương thức Main thực hiện nhập dữ liệu thông qua thư viện hỗ trợ InputHelper, kiểm tra tính hợp lệ của năm sinh (năm sinh > 0 và <= năm hiện tại) trước khi tạo đối tượng và gọi phương thức tính tuổi."""
    },

    # BÀI 1.2
    {
        "title": "Bài 1.2: Thiết kế lớp Point",
        "folder": "bai2",
        "problem": """Thiết kế lớp Point có chức năng sau:
• Field: x, y
• Property: X, Y
• Constructor: default constructor khởi tạo giá trị ban đầu cho x và y bằng 0
• Method: Input và Output để nhập xuất toạ độ (x, y)
• Override hàm ToString() để xuất Point
• Phép toán: +, -, lấy âm (-)
Xây dựng các chức năng sau cho lớp Point:
(a) Khoảng cách giữa 2 điểm: Viết chương trình tính khoảng cách giữa 2 điểm A và B trong mặt phẳng tọa độ theo 2 cách (Phương thức thành viên & Phương thức tĩnh).
(b) Trung điểm của 2 điểm: Viết chương xác định trung điểm I của 2 điểm A và B theo 2 cách (Phương thức thành viên & Phương thức tĩnh).""",
        "code_files": [
            {
                "filename": "bai2.cs",
                "content": read_file(os.path.join(base_dir, "bai2", "bai2.cs"))
            }
        ],
        "output": """Diem A: (3,4)
Diem B: (1,2)

--- PHEP TOAN ---
A + B = (4,6)
A - B = (2,2)
-A = (-3,-4)

--- KHOANG CACH ---
Member Method A.DistanceTo(B)( thanh vien): 2.83
Static Method Point.Distance(A, B)( tinh): 2.83

--- TRUNG DIEM ---
Member Method A.MidpointWith(B)( thanh vien): (2,3)
Static Method Point.Midpoint(A, B)( tinh): (2,3)""",
        "idea": """• Thiết kế lớp Point biểu diễn một điểm trong không gian 2 chiều (Oxy):
  - Dữ liệu (Fields & Properties): x, y kiểu số thực (double) được bao bọc bởi các thuộc tính X, Y.
  - Nạp chồng toán tử (Operator Overloading):
    + Toán tử 2 ngôi (+, -): Cộng/trừ tọa độ tương ứng (x1+x2, y1+y2) và (x1-x2, y1-y2).
    + Toán tử 1 ngôi (-): Đổi dấu tọa độ điểm (-x, -y).
  - Khoảng cách (Distance): Áp dụng công thức d = sqrt((x1-x2)^2 + (y1-y2)^2). Được cài đặt theo 2 dạng:
    + Phương thức thành viên: A.DistanceTo(B) (sử dụng tọa độ đối tượng hiện tại this và đối tượng truyền vào).
    + Phương thức tĩnh: Point.Distance(A, B) (nhận 2 đối tượng Point độc lập).
  - Trung điểm (Midpoint): Tọa độ I = ((x1+x2)/2, (y1+y2)/2). Cài đặt tương tự gồm phương thức thể hiện MidpointWith() và phương thức tĩnh Midpoint()."""
    },

    # BÀI 1.3
    {
        "title": "Bài 1.3: Quản lý thông tin đối tượng Person",
        "folder": "bai3",
        "problem": """Cho lớp Person dùng quản lý thông tin của một người. Dữ liệu thành viên của Person gồm có: id, name, yob (năm sinh), yod (năm mất). Lớp Person có một số phương thức:
• Default Constructor, Copy constructor
• Input(), Output(): Nhập, xuất các dữ liệu của Person
• IsLiving(): Trả về false hay true tùy thuộc vào yod bằng 0 hay khác 0
Yêu cầu: Định nghĩa lớp Person.""",
        "code_files": [
            {
                "filename": "bai3.cs",
                "content": read_file(os.path.join(base_dir, "bai3", "bai3.cs"))
            },
            {
                "filename": "program.cs",
                "content": read_file(os.path.join(base_dir, "bai3", "program.cs"))
            }
        ],
        "output": """--- NHAP THONG TIN PERSON 1 ---
Nhap ID: PS001
Nhap Ho ten: Tran Van Bao
Nhap Nam Sinh: 1995
Nhap nam mat (YOD) [Nhap 0 neu con song]: 0

--- THONG TIN PERSON 1 ---
ID: PS001 | Ten: Tran Van Bao | Nam sinh: 1995 | Trang thai: Con song

--- SAO CHEP SANG PERSON 2 (COPY CONSTRUCTOR) ---
ID: PS001 | Ten: Tran Van Bao | Nam sinh: 1995 | Trang thai: Con song

Person 1 con song hay khong? -> True""",
        "idea": """• Thiết kế lớp Person:
  - Thuộc tính thành viên: id (mã định danh), name (họ tên), yob (năm sinh), yod (năm mất).
  - Cơ chế khởi tạo:
    + Default constructor: Thiết lập các giá trị chuỗi rỗng và năm sinh/mất mặc định là 0.
    + Parameterized constructor: Thiết lập đầy đủ các trường id, name, yob, yod.
    + Copy constructor: Tạo bản sao sâu (deep copy) giá trị của một đối tượng Person khác.
  - Phương thức IsLiving(): Kiểm tra nếu yod == 0 tức là người đó hiện vẫn còn sống (trả về true), ngược lại đã mất (trả về false).
  - Xử lý ràng buộc: Kiểm tra tính hợp lệ khi nhập liệu (năm mất yod nếu khác 0 thì phải lớn hơn hoặc bằng năm sinh yob và năm sinh không vượt quá năm hiện tại)."""
    },

    # BÀI 1.4
    {
        "title": "Bài 1.4: Thiết kế lớp Phân số (PhanSo)",
        "folder": "bai4",
        "problem": """Thiết kế lớp Phân số có chức năng:
• Constructor: Constructor Mặc nhiên, Constructor sao chép và một số constructor khác để khởi tạo dữ liệu cho phân số
• Override hàm ToString() để xuất phân số
• Overload các toán tử:
  - Một ngôi: +, -
  - Hai ngôi: +, -, *, /
  - So sánh: >, <, >=, <=, ==, !=""",
        "code_files": [
            {
                "filename": "bai4.cs",
                "content": read_file(os.path.join(base_dir, "bai4", "bai4.cs"))
            }
        ],
        "output": """Nhap x1: 1
Nhap y1: 2
Nhap x2: 3
Nhap y2: 4
==========================================
p1 = 0
p2 = 1/2
p3 = 3/4
p4 (sao chep p2) = 1/2

--- TOAN TU 1 NGOI ---
+p2 = 1/2
-p2 = -1/2

--- TOAN TU 2 NGOI ---
1/2 + 3/4 = 5/4
1/2 - 3/4 = -1/4
1/2 * 3/4 = 3/8
1/2 / 3/4 = 2/3

--- TOAN TU SO SANH ---
1/2 == 1/2 : True
1/2 != 3/4 : True
1/2 > 3/4  : False
1/2 <= 3/4 : True""",
        "idea": """• Thiết kế lớp PhanSo:
  - Dữ liệu: tuso (tử số), mauso (mẫu số != 0).
  - Thuật toán rút gọn: Sử dụng thuật toán Euclid tìm ước chung lớn nhất (UCLN) để chuẩn hóa phân số ngay sau khi khởi tạo hoặc thực hiện phép toán, đồng thời đưa dấu âm về tử số nếu mẫu số âm.
  - Overload đầy đủ các toán tử:
    + Toán tử số học (+, -, *, /): Áp dụng quy tắc cộng trừ quy đồng, nhân tử với tử, mẫu với mẫu, chia nhân nghịch đảo.
    + Toán tử so sánh: Quy đồng chéo a/b và c/d tương đương so sánh a*d và c*b (khi mẫu số dương). Cài đặt đồng thời cặp toán tử == và !=, > và <, >= và <=, kết hợp ghi đè Equals() và GetHashCode() để tuân thủ chuẩn OOP trong C#."""
    },

    # BÀI 1.5
    {
        "title": "Bài 1.5: Xây dựng lớp Đơn thức (DonThuc)",
        "folder": "bai5",
        "problem": """Xây dựng lớp Đơn thức thực hiện chức năng sau:
(a) Tính giá trị đơn thức P(x) = a * x^n (a là số thực, n là số nguyên không âm) với giá trị x cho trước.
(b) Đạo hàm đơn thức P(x) = a * x^n theo qui tắc đạo hàm: Q(x) = P'(x) = a * n * x^(n - 1)""",
        "code_files": [
            {
                "filename": "bai5.cs",
                "content": read_file(os.path.join(base_dir, "bai5", "bai5.cs"))
            }
        ],
        "output": """Nhap he so: 3
Nhap so mu: 2
Nhap x: 2
===================================
Don thuc la: 3x^2
Gia tri P(2) = 12
Dao ham: 6x^1""",
        "idea": """• Thiết kế lớp DonThuc:
  - Thuộc tính: heso (hệ số a kiểu double), somu (số mũ n kiểu int >= 0).
  - Tính giá trị Calculating(double x): Trả về heso * Math.Pow(x, somu).
  - Đạo hàm derivative():
    + Nếu somu == 0 (hằng số), đạo hàm có giá trị bằng 0 (trả về DonThuc(0, 0)).
    + Nếu somu > 0, hệ số mới = heso * somu, số mũ mới = somu - 1.
  - Định dạng chuỗi ToString() hiển thị đúng dạng ax^n (hoặc tối ưu rút gọn trong các bài toán đa thức)."""
    },

    # BÀI 2.1
    {
        "title": "Bài 2.1: Lớp ArrayPoint quản lý danh sách Point",
        "folder": "bai6",
        "problem": """Thiết kế lớp ArrayPoint có chức năng lưu trữ các Point:
• Field: Một ArrayList các Point
• Indexer cho phép truy cập Point thứ i của ArrayList""",
        "code_files": [
            {
                "filename": "bai6.cs",
                "content": read_file(os.path.join(base_dir, "bai6", "bai6.cs"))
            }
        ],
        "output": """Point tại vị trí 0: X = 1, Y = 2
Point tại vị trí 1 sau khi sửa: X = 10, Y = 20""",
        "idea": """• Thiết kế lớp ArrayPoint:
  - Field: Sử dụng ArrayList để lưu trữ động tập hợp các đối tượng Point (tái sử dụng lớp Point từ Bài 1.2).
  - Cài đặt Indexer (public Point this[int i]): Cho phép người dùng truy cập và gán giá trị cho phần tử thứ i giống như thao tác trên mảng thông thường (arrayPoint[i]).
  - Kiểm tra phạm vi (Bound Checking): Ném ngoại lệ IndexOutOfRangeException nếu chỉ số i nằm ngoài giới hạn [0, points.Count - 1] nhằm đảm bảo tính an toàn dữ liệu."""
    },

    # BÀI 2.2
    {
        "title": "Bài 2.2: Quản lý nhân khẩu với PersonList",
        "folder": "bai7",
        "problem": """Một địa phương cần quản lý nhân khẩu nên đã thiết kế lớp PersonList dùng để quản lý nhiều người khác nhau. Lớp PersonList có một số phương thức sau:
• Default constructor, Copy constructor
• Input(), Output(): Nhập, xuất các dữ liệu của PersonList
• Add(Person x): Thêm một Person vào trong PersonList
• LivingPeople(): Trả về một PersonList những người còn sống
Yêu cầu: Định nghĩa lớp PersonList dựa trên lớp Person như mô tả ở trên.""",
        "code_files": [
            {
                "filename": "bai7.cs",
                "content": read_file(os.path.join(base_dir, "bai7", "bai7.cs"))
            }
        ],
        "output": """--- nhap danh sach nhan khau ---
Nhap So luong nguoi: 2
Nhap thong tin nguoi thu 1:
Nhap ID: P01
Nhap Ho ten: Nguyen Van A
Nhap Nam Sinh: 1980
Nhap nam mat (YOD) [Nhap 0 neu con song]: 0
Nhap thong tin nguoi thu 2:
Nhap ID: P02
Nhap Ho ten: Tran Van B
Nhap Nam Sinh: 1940
Nhap nam mat (YOD) [Nhap 0 neu con song]: 2015

=================================
danh sach cac nhan khau:
--- Nguoi thu 1 ---
ID: P01 | Ten: Nguyen Van A | Nam sinh: 1980 | Trang thai: Con song
--- Nguoi thu 2 ---
ID: P02 | Ten: Tran Van B | Nam sinh: 1940 | Trang thai: Da mat (Nam 2015)

=================================
danh sach cac nguoi con song:
--- Nguoi thu 1 ---
ID: P01 | Ten: Nguyen Van A | Nam sinh: 1980 | Trang thai: Con song

=================================
kiem tra copy constructor, tao ban sao list:
--- Nguoi thu 1 ---
ID: P01 | Ten: Nguyen Van A | Nam sinh: 1980 | Trang thai: Con song
--- Nguoi thu 2 ---
ID: P02 | Ten: Tran Van B | Nam sinh: 1940 | Trang thai: Da mat (Nam 2015)""",
        "idea": """• Thiết kế lớp PersonList:
  - Lưu trữ danh sách đối tượng Person bằng List<Person> nội bộ.
  - Tái sử dụng tối đa các phương thức của lớp Person (Bài 1.3):
    + Phương thức Add(Person p) kiểm tra null trước khi thêm vào danh sách.
    + Phương thức LivingPeople() duyệt qua danh sách, gọi p.IsLiving(), nếu true thì thêm vào danh sách kết quả mới và trả về một đối tượng PersonList chứa toàn bộ người còn sống.
    + Copy constructor duyệt qua từng phần tử và tạo mới từng Person qua copy constructor của Person, đảm bảo tính toàn vẹn độc lập (deep copy)."""
    },

    # BÀI 2.3
    {
        "title": "Bài 2.3: Lớp chứa mảng 1 chiều (DaySo)",
        "folder": "bai8",
        "problem": """Xây dựng lớp dãy số chứa n số nguyên. Hãy viết các phương thức:
a. Các loại Constructor
b. Indexer để truy cập phần tử thứ i trong dãy
c. Nhập / Xuất dãy số
d. Tìm các số chẵn""",
        "code_files": [
            {
                "filename": "bai8.cs",
                "content": read_file(os.path.join(base_dir, "bai8", "bai8.cs"))
            }
        ],
        "output": """Nhap day so:
Nhap So luong phan tu n: 5
Nhap Phan tu a[0]: 12
Nhap Phan tu a[1]: 5
Nhap Phan tu a[2]: 8
Nhap Phan tu a[3]: 19
Nhap Phan tu a[4]: 20

day so vua nhap:
Day so: 12 5 8 19 20

phan tu dau tien (ds1[0]): 12
day so sau khi sua:
Day so: 999 5 8 19 20

danh sach cac so chan:
Day so: 8 20

tao ban sao day so co san:
Day so: 999 5 8 19 20""",
        "idea": """• Thiết kế lớp DaySo:
  - Trường dữ liệu: mảng số nguyên int[] a.
  - Đa dạng Constructor: Constructor rỗng, Constructor khởi tạo kích thước n, Constructor từ mảng int[], Copy Constructor sao chép mảng an toàn qua Array.Copy().
  - Indexer (public int this[int i]): Giúp truy xuất/gán phần tử a[i] thuận tiện, đồng thời kiểm tra ngoại lệ vượt biên.
  - Tìm số chẵn TimSoChan(): Duyệt qua mảng a, lọc các phần tử item % 2 == 0 đưa vào danh sách, sau đó đóng gói trả về một đối tượng DaySo mới chứa toàn bộ các số chẵn."""
    },

    # BÀI 2.4
    {
        "title": "Bài 2.4: Lớp chứa mảng 2 chiều (MangHaiChieu)",
        "folder": "bai9",
        "problem": """Xây dựng lớp mảng 2 chiều có kích thước nxm. Hãy viết các phương thức:
a. Các loại constructor
b. Indexer để truy cập phần tử tại (i, j)
c. Nhập / Xuất
d. Tìm các số nguyên tố trong mảng""",
        "code_files": [
            {
                "filename": "bai9.cs",
                "content": read_file(os.path.join(base_dir, "bai9", "bai9.cs"))
            }
        ],
        "output": """Nhap So dong n: 2
Nhap So cot m: 3
--- Nhap dong 1 ---
Nhap Phan tu [0, 0]: 2
Nhap Phan tu [0, 1]: 4
Nhap Phan tu [0, 2]: 5
--- Nhap dong 2 ---
Nhap Phan tu [1, 0]: 7
Nhap Phan tu [1, 1]: 9
Nhap Phan tu [1, 2]: 11

Mang 2 chieu vua nhap:
Mang 2 chieu (2x3):
Day so: 2 4 5
Day so: 7 9 11

Cac so nguyen to trong mang:
Day so: 2 5 7 11""",
        "idea": """• Thiết kế lớp MangHaiChieu theo hướng tái sử dụng thành phần:
  - Cấu trúc: Lưu mảng 2 chiều dưới dạng một mảng các dòng DaySo[] rows (tái sử dụng lớp DaySo ở Bài 2.3).
  - Indexer 2 chiều (public int this[int i, int j]): Truy cập phần tử hàng i, cột j bằng rows[i][j], kết hợp kiểm tra tính hợp lệ của chỉ số dòng và cột.
  - Tìm số nguyên tố TimSoNguyenTo(): Duyệt qua toàn bộ ma trận, kiểm tra số nguyên tố (tái sử dụng hàm kiểm tra số nguyên tố từ SharedLibs/Tuan1) và trả về kết quả dưới dạng đối tượng DaySo."""
    },

    # BÀI 2.3 (Phần 2)
    {
        "title": "Bài 2.3 (Phần 2): Thiết kế lớp Đa thức (DaThuc)",
        "folder": "bai10",
        "problem": """Xây dựng lớp đa thức gồm n+1 đơn thức:
P(x) = a0 + a1*x + a2*x^2 + ... + an*x^n
Viết các phương thức sau:
a. Các loại constructor
b. Indexer để truy cập đơn thức thứ i
c. Nhập / Xuất
d. Tính giá trị của đa thức với giá trị x được nhập từ bàn phím""",
        "code_files": [
            {
                "filename": "bai10.cs",
                "content": read_file(os.path.join(base_dir, "bai10", "bai10.cs"))
            },
            {
                "filename": "program.cs",
                "content": read_file(os.path.join(base_dir, "bai10", "program.cs"))
            }
        ],
        "output": """Nhap bac cua da thuc n: 2
--- Nhap he so cho da thuc bac 2 ---
Nhap he so thu 1 (cho x^0): 2
Nhap he so thu 2 (cho x^1): 3
Nhap he so thu 3 (cho x^2): 4

P(x) = 2 + 3x + 4x^2
Don thuc bac 1 cua da thuc la: 3x^1
Nhap x: 2
Gia tri P(2) = 24""",
        "idea": """• Thiết kế lớp DaThuc:
  - Dữ liệu: Mảng các đơn thức DonThuc[] DsDonThuc có kích thước bac + 1 (tái sử dụng lớp DonThuc ở Bài 1.5).
  - Indexer: Cho phép truy cập hoặc thay đổi đơn thức bậc i thông qua dt[i].
  - Định dạng xuất ToString(): Xử lý thông minh các trường hợp đặc biệt (bỏ qua hệ số 0, xử lý hệ số 1, -1, số mũ 0, số mũ 1, chuẩn hóa định dạng nối dấu '+' và '-').
  - Tính giá trị Calculate(double x): Duyệt qua mảng đơn thức, cộng dồn giá trị tính được từ phương thức Calculating(x) của từng DonThuc."""
    },

    # BÀI 2.4 (Phần 2)
    {
        "title": "Bài 2.4 (Phần 2): Dãy phân số (DayPS)",
        "folder": "bai11",
        "problem": """Xây dựng lớp chứa n phân số. Hãy tính tổng của n phân số đó.""",
        "code_files": [
            {
                "filename": "bai11.cs",
                "content": read_file(os.path.join(base_dir, "bai11", "bai11.cs"))
            },
            {
                "filename": "Program.cs",
                "content": read_file(os.path.join(base_dir, "bai11", "Program.cs"))
            }
        ],
        "output": """Nhap so luong phan so n: 3

--- Nhap phan so thu 1 ---
Nhap tu so: 1
Nhap mau so: 2

--- Nhap phan so thu 2 ---
Nhap tu so: 1
Nhap mau so: 3

--- Nhap phan so thu 3 ---
Nhap tu so: 1
Nhap mau so: 4

Day phan so: [ 1/2; 1/3; 1/4 ]
Tong cua day phan so la: 13/12""",
        "idea": """• Thiết kế lớp DayPS:
  - Chứa mảng các phân số PhanSo[] dayphanso (tái sử dụng lớp PhanSo từ Bài 1.4).
  - Phương thức TinhTong(): Khởi tạo biến tích lũy tong = new PhanSo(0, 1), sau đó dùng vòng lặp duyệt qua từng phần tử và áp dụng toán tử cộng '+' đã nạp chồng trong lớp PhanSo: tong = tong + ps. Kết quả trả về là một phân số đã được tự động rút gọn tối giản."""
    },

    # BÀI 2.5
    {
        "title": "Bài 2.5: Tính lương nhân viên (PhongBan)",
        "folder": "bai12",
        "problem": """Một phòng ban có n nhân viên (họ tên, mức lương, số ngày vắng). Biết rằng một ngày vắng sẽ bị trừ 100.000 VNĐ. Hãy tính tổng lương của phòng ban.""",
        "code_files": [
            {
                "filename": "bai12.cs",
                "content": read_file(os.path.join(base_dir, "bai12", "bai12.cs"))
            },
            {
                "filename": "Program.cs",
                "content": read_file(os.path.join(base_dir, "bai12", "Program.cs"))
            }
        ],
        "output": """Nhap so luong nhan vien n: 3

--- Nhap thong tin nhan vien thu 1 ---
Nhap ho ten nhan vien: Nguyen Van C
Nhap muc luong co ban: 10000000
Nhap so ngay vang: 3

--- Nhap thong tin nhan vien thu 2 ---
Nhap ho ten nhan vien: Tran Thi A
Nhap muc luong co ban: 15000000
Nhap so ngay vang: 1

--- Nhap thong tin nhan vien thu 3 ---
Nhap ho ten nhan vien: Le Van B
Nhap muc luong co ban: 12000000
Nhap so ngay vang: 5

=================== danh sach luong nhan vien trong phong ban ===================
1. Ho ten: Nguyen Van C         | Luong co ban:   10,000,000 VNĐ | So ngay vang:  3 | Luong thuc nhan:    9,700,000 VNĐ
2. Ho ten: Tran Thi A           | Luong co ban:   15,000,000 VNĐ | So ngay vang:  1 | Luong thuc nhan:   14,900,000 VNĐ
3. Ho ten: Le Van B             | Luong co ban:   12,000,000 VNĐ | So ngay vang:  5 | Luong thuc nhan:   11,500,000 VNĐ
-----------------------------------------------------------------
=> tong luong phong ban: 36,100,000 VNĐ""",
        "idea": """• Thiết kế gồm 2 lớp:
  - Lớp NhanVien: Chứa HoTen, MucLuong, SoNgayVang. Phương thức TinhLuong() tính lương thực nhận = Math.Max(0, MucLuong - SoNgayVang * 100,000). Cài đặt giao diện IComparable<NhanVien> phục vụ so sánh và sắp xếp.
  - Lớp PhongBan: Chứa mảng NhanVien[] dsNhanVien. Phương thức TinhTongLuong() duyệt qua danh sách nhân viên và cộng dồn kết quả từ TinhLuong() của từng nhân viên."""
    },

    # BÀI 3.1
    {
        "title": "Bài 3.1: Sắp xếp đối tượng với phương thức tĩnh Array.Sort(...)",
        "folder": "bai13",
        "problem": """Dùng phương thức tĩnh Array.Sort(...) để sắp xếp các đối tượng của một lớp nào đó (Áp dụng cho mảng đối tượng NhanVien).""",
        "code_files": [
            {
                "filename": "bai13.cs",
                "content": read_file(os.path.join(base_dir, "bai13", "bai13.cs"))
            },
            {
                "filename": "Program.cs",
                "content": read_file(os.path.join(base_dir, "bai13", "Program.cs"))
            }
        ],
        "output": """================ danh sach ban dau ================
1. Ho ten: Nguyen Van C         | Luong co ban:   10,000,000 VNĐ | So ngay vang:  3 | Luong thuc nhan:    9,700,000 VNĐ
2. Ho ten: Tran Thi A           | Luong co ban:   15,000,000 VNĐ | So ngay vang:  1 | Luong thuc nhan:   14,900,000 VNĐ
3. Ho ten: Le Van B             | Luong co ban:   12,000,000 VNĐ | So ngay vang:  5 | Luong thuc nhan:   11,500,000 VNĐ
4. Ho ten: Pham Thi D           | Luong co ban:    8,000,000 VNĐ | So ngay vang:  0 | Luong thuc nhan:    8,000,000 VNĐ

==== sap xep theo ten (A -> Z) ====
1. Ho ten: Le Van B             | Luong co ban:   12,000,000 VNĐ | So ngay vang:  5 | Luong thuc nhan:   11,500,000 VNĐ
2. Ho ten: Nguyen Van C         | Luong co ban:   10,000,000 VNĐ | So ngay vang:  3 | Luong thuc nhan:    9,700,000 VNĐ
3. Ho ten: Pham Thi D           | Luong co ban:    8,000,000 VNĐ | So ngay vang:  0 | Luong thuc nhan:    8,000,000 VNĐ
4. Ho ten: Tran Thi A           | Luong co ban:   15,000,000 VNĐ | So ngay vang:  1 | Luong thuc nhan:   14,900,000 VNĐ

==== sap xep theo luong( giam dan) ====
1. Ho ten: Tran Thi A           | Luong co ban:   15,000,000 VNĐ | So ngay vang:  1 | Luong thuc nhan:   14,900,000 VNĐ
2. Ho ten: Le Van B             | Luong co ban:   12,000,000 VNĐ | So ngay vang:  5 | Luong thuc nhan:   11,500,000 VNĐ
3. Ho ten: Nguyen Van C         | Luong co ban:   10,000,000 VNĐ | So ngay vang:  3 | Luong thuc nhan:    9,700,000 VNĐ
4. Ho ten: Pham Thi D           | Luong co ban:    8,000,000 VNĐ | So ngay vang:  0 | Luong thuc nhan:    8,000,000 VNĐ""",
        "idea": """• Áp dụng phương thức tĩnh Array.Sort() theo 2 cơ chế:
  - Cơ chế 1 (Mặc định qua IComparable): Lớp NhanVien thực thi giao diện IComparable<NhanVien>, ghi đè phương thức CompareTo() để so sánh mức lương thực nhận giảm dần. Khi gọi Array.Sort(dsNhanVien), .NET tự động sử dụng CompareTo để sắp xếp danh sách theo lương.
  - Cơ chế 2 (Thông qua Comparison delegate): Truyền trực tiếp hàm so sánh tùy biến SoSanhTheoTen vào Array.Sort(dsNhanVien, SoSanhTheoTen) để sắp xếp danh sách theo bảng chữ cái họ tên (A -> Z) một cách linh hoạt."""
    },

    # BÀI 3.2
    {
        "title": "Bài 3.2: Sắp xếp mảng tổng quát bằng Interface",
        "folder": "bai14",
        "problem": """Viết phương thức sắp xếp một mảng tổng quát bằng interface (mô phỏng phương thức Array.Sort(…)).""",
        "code_files": [
            {
                "filename": "bai14.cs",
                "content": read_file(os.path.join(base_dir, "bai14", "bai14.cs"))
            },
            {
                "filename": "Program.cs",
                "content": read_file(os.path.join(base_dir, "bai14", "Program.cs"))
            }
        ],
        "output": """=== mang so nguyen ban dau ===
42, 15, 88, 3, 27, 19
=== mang so nguyen sap xep tang dan, cach 1 ===
3, 15, 19, 27, 42, 88

================ danh sach ban dau ================
1. Ho ten: Nguyen Van C         | Luong co ban:   10,000,000 VNĐ | So ngay vang:  3 | Luong thuc nhan:    9,700,000 VNĐ
2. Ho ten: Tran Thi A           | Luong co ban:   15,000,000 VNĐ | So ngay vang:  1 | Luong thuc nhan:   14,900,000 VNĐ
3. Ho ten: Le Van B             | Luong co ban:   12,000,000 VNĐ | So ngay vang:  5 | Luong thuc nhan:   11,500,000 VNĐ
4. Ho ten: Pham Thi D           | Luong co ban:    8,000,000 VNĐ | So ngay vang:  0 | Luong thuc nhan:    8,000,000 VNĐ

==== cach 1 (IComparable): sap xep theo luong giam dan ====
1. Ho ten: Tran Thi A           | Luong co ban:   15,000,000 VNĐ | So ngay vang:  1 | Luong thuc nhan:   14,900,000 VNĐ
2. Ho ten: Le Van B             | Luong co ban:   12,000,000 VNĐ | So ngay vang:  5 | Luong thuc nhan:   11,500,000 VNĐ
3. Ho ten: Nguyen Van C         | Luong co ban:   10,000,000 VNĐ | So ngay vang:  3 | Luong thuc nhan:    9,700,000 VNĐ
4. Ho ten: Pham Thi D           | Luong co ban:    8,000,000 VNĐ | So ngay vang:  0 | Luong thuc nhan:    8,000,000 VNĐ

==== CÁCH 2 (IComparer): SẮP XẾP THEO TÊN (A -> Z) ====
1. Ho ten: Le Van B             | Luong co ban:   12,000,000 VNĐ | So ngay vang:  5 | Luong thuc nhan:   11,500,000 VNĐ
2. Ho ten: Nguyen Van C         | Luong co ban:   10,000,000 VNĐ | So ngay vang:  3 | Luong thuc nhan:    9,700,000 VNĐ
3. Ho ten: Pham Thi D           | Luong co ban:    8,000,000 VNĐ | So ngay vang:  0 | Luong thuc nhan:    8,000,000 VNĐ
4. Ho ten: Tran Thi A           | Luong co ban:   15,000,000 VNĐ | So ngay vang:  1 | Luong thuc nhan:   14,900,000 VNĐ

==== CÁCH 2 (IComparer): SẮP XẾP THEO NGÀY VẮNG TĂNG DẦN ====
1. Ho ten: Pham Thi D           | Luong co ban:    8,000,000 VNĐ | So ngay vang:  0 | Luong thuc nhan:    8,000,000 VNĐ
2. Ho ten: Tran Thi A           | Luong co ban:   15,000,000 VNĐ | So ngay vang:  1 | Luong thuc nhan:   14,900,000 VNĐ
3. Ho ten: Nguyen Van C         | Luong co ban:   10,000,000 VNĐ | So ngay vang:  3 | Luong thuc nhan:    9,700,000 VNĐ
4. Ho ten: Le Van B             | Luong co ban:   12,000,000 VNĐ | So ngay vang:  5 | Luong thuc nhan:   11,500,000 VNĐ""",
        "idea": """• Xây dựng lớp CustomArray triển khai thuật toán QuickSort tổng quát (Generic):
  - Phương thức 1: Sort<T>(T[] array) where T : IComparable<T> -> Ràng buộc kiểu T phải thực thi IComparable<T>, dùng method CompareTo() để so sánh và phân hoạch mảng.
  - Phương thức 2: Sort<T>(T[] array, IComparer<T> comparer) -> Cho phép đối tượng so sánh độc lập (Comparator) bên ngoài như NhanVienTenComparer, NhanVienNgayVangComparer điều khiển tiêu chí sắp xếp mà không cần sửa đổi mã nguồn lớp ban đầu."""
    },

    # BÀI 3.3
    {
        "title": "Bài 3.3: Sắp xếp mảng tổng quát bằng Delegate",
        "folder": "bai15",
        "problem": """Viết phương thức sắp xếp một mảng tổng quát bằng delegate.""",
        "code_files": [
            {
                "filename": "bai15.cs",
                "content": read_file(os.path.join(base_dir, "bai15", "bai15.cs"))
            },
            {
                "filename": "Program.cs",
                "content": read_file(os.path.join(base_dir, "bai15", "Program.cs"))
            }
        ],
        "output": """==== lan 1 bubble sort theo ho ten (A -> Z) ====
1. Ho ten: Le Van B             | Luong co ban:   12,000,000 VNĐ | So ngay vang:  5 | Luong thuc nhan:   11,500,000 VNĐ
2. Ho ten: Nguyen Van C         | Luong co ban:   10,000,000 VNĐ | So ngay vang:  3 | Luong thuc nhan:    9,700,000 VNĐ
3. Ho ten: Pham Thi D           | Luong co ban:    8,000,000 VNĐ | So ngay vang:  0 | Luong thuc nhan:    8,000,000 VNĐ
4. Ho ten: Tran Thi A           | Luong co ban:   15,000,000 VNĐ | So ngay vang:  1 | Luong thuc nhan:   14,900,000 VNĐ

==== lan 1 bubble sort theo luong thuc nhan (giam dan) ====
1. Ho ten: Tran Thi A           | Luong co ban:   15,000,000 VNĐ | So ngay vang:  1 | Luong thuc nhan:   14,900,000 VNĐ
2. Ho ten: Le Van B             | Luong co ban:   12,000,000 VNĐ | So ngay vang:  5 | Luong thuc nhan:   11,500,000 VNĐ
3. Ho ten: Nguyen Van C         | Luong co ban:   10,000,000 VNĐ | So ngay vang:  3 | Luong thuc nhan:    9,700,000 VNĐ
4. Ho ten: Pham Thi D           | Luong co ban:    8,000,000 VNĐ | So ngay vang:  0 | Luong thuc nhan:    8,000,000 VNĐ

==== lan 1 bubble sort theo so ngay vang (tang dan) ====
1. Ho ten: Pham Thi D           | Luong co ban:    8,000,000 VNĐ | So ngay vang:  0 | Luong thuc nhan:    8,000,000 VNĐ
2. Ho ten: Tran Thi A           | Luong co ban:   15,000,000 VNĐ | So ngay vang:  1 | Luong thuc nhan:   14,900,000 VNĐ
3. Ho ten: Nguyen Van C         | Luong co ban:   10,000,000 VNĐ | So ngay vang:  3 | Luong thuc nhan:    9,700,000 VNĐ
4. Ho ten: Le Van B             | Luong co ban:   12,000,000 VNĐ | So ngay vang:  5 | Luong thuc nhan:   11,500,000 VNĐ""",
        "idea": """• Sử dụng Delegate trong thuật toán sắp xếp:
  - Khai báo delegate tổng quát: public delegate int SoSanhDelegate<T>(T x, T y).
  - Cài đặt thuật toán BubbleSort: Duyệt qua mảng và so sánh hai phần tử liền kề array[j] và array[j+1] bằng cách gọi delegate comparer(array[j], array[j+1]). Nếu kết quả > 0 thì hoán vị (swap).
  - Hỗ trợ cả delegate tự định nghĩa và delegate dựng sẵn của .NET là Comparison<T>, cho phép truyền bất kỳ hàm so sánh nào (hoặc biểu thức Lambda) vào phương thức sắp xếp."""
    },

    # BÀI 3.4
    {
        "title": "Bài 3.4*: Xây dựng lớp ConsoleMenu tổng quát",
        "folder": "bai16",
        "problem": """Xây dựng lớp ConsoleMenu tổng quát có chức năng:
Menu
1. Chức năng 1
2. Chức năng 2
...
0. Thoát chương trình
Thực hiện: x -> Bạn thực hiện chức năng x
Áp dụng cho bài toán giải phương trình bậc 2, với thư viện hỗ trợ mở rộng qua sự kiện (Event), kế thừa (Inheritance).""",
        "code_files": [
            {
                "filename": "bai16.cs",
                "content": read_file(os.path.join(base_dir, "bai16", "bai16.cs"))
            },
            {
                "filename": "Program.cs",
                "content": read_file(os.path.join(base_dir, "bai16", "Program.cs"))
            }
        ],
        "output": """Menu
1. Nhap he so(a,b,c) de giai phuong trinh bac 2: ax^2 + bx + c = 0
2. Xem huong dan su dung
0. Thoát chương trình
Nhap lua chon: 1
Bạn thực hiện chức năng 1
Nhap a: 1
Nhap b: -3
Nhap c: 2
[ket qua]: Phuong trinh co 2 nghiem phan biet: x1 = 2, x2 = 1

Menu
1. Nhap he so(a,b,c) de giai phuong trinh bac 2: ax^2 + bx + c = 0
2. Xem huong dan su dung
0. Thoát chương trình
Nhap lua chon: 0
Đã thoát chương trình!""",
        "idea": """• Thiết kế lớp cơ sở ConsoleMenu:
  - Sử dụng cấu trúc danh sách List<MenuItem> lưu trữ các mục lựa chọn, trong đó mỗi MenuItem chứa tiêu đề Title và delegate Action tương ứng.
  - Hỗ trợ Event OnOptionExecuted phát tín hiệu khi người dùng chọn thực thi một chức năng.
  - Thiết kế lớp PhuongTrinhMenu kế thừa từ ConsoleMenu: Đăng ký các chức năng giải PTB2 thông qua phương thức AddOption().
  - Lớp PhuongTrinhBac2 phát sự kiện TinhToanXong khi giải xong để menu đăng ký lắng nghe và hiển thị kết quả, đảm bảo nguyên lý thiết kế lỏng lẻo (loose coupling) và mở rộng linh hoạt."""
    },

    # BÀI 3.5
    {
        "title": "Bài 3.5: Kế thừa và Đa hình - Tính lương nhân viên",
        "folder": "bai17",
        "problem": """Trong một công ty X, các nhân viên thuộc một trong 2 bộ phận: nhân viên kinh doanh và nhân viên sản xuất. Thông tin cơ bản: Mã nhân viên, họ tên.
Cách tính lương:
• Nhân viên kinh doanh: Ngoài lương cơ bản, nhận thêm 500.000 VNĐ / hợp đồng ký kết.
• Nhân viên sản xuất: Lương = số lượng sản phẩm x 1.000 VNĐ. Nếu sản xuất trên 3.000 sản phẩm thì được thưởng thêm 5% lương.
Viết chương trình tính lương cho các nhân viên.""",
        "code_files": [
            {
                "filename": "bai17.cs",
                "content": read_file(os.path.join(base_dir, "bai17", "bai17.cs"))
            },
            {
                "filename": "Program.cs",
                "content": read_file(os.path.join(base_dir, "bai17", "Program.cs"))
            }
        ],
        "output": """QUẢN LÝ LƯƠNG CÔNG TY
1. Hiển thị bảng lương toàn công ty
2. Tính tổng tiền lương công ty phải trả
3. Thêm Nhân viên Kinh doanh
4. Thêm Nhân viên Sản xuất
0. Thoát chương trình
Nhap lua chon: 1
Bạn thực hiện chức năng 1
================ DANH SÁCH BẢNG LƯƠNG ================
1. Mã NV: KD01 | Họ tên: Nguyễn Văn A | Bo phan: Kinh Doanh| Luong:    9,500,000 VNĐ
2. Mã NV: SX01 | Họ tên: Trần Thị B   | Bo phan: san xuat  | Luong:    2,500,000 VNĐ
3. Mã NV: SX02 | Họ tên: Lê Văn C     | Bo phan: san xuat  | Luong:    3,675,000 VNĐ
4. Mã NV: KD02 | Họ tên: Phạm Thị D   | Bo phan: Kinh Doanh| Luong:    9,000,000 VNĐ

QUẢN LÝ LƯƠNG CÔNG TY
1. Hiển thị bảng lương toàn công ty
2. Tính tổng tiền lương công ty phải trả
3. Thêm Nhân viên Kinh doanh
4. Thêm Nhân viên Sản xuất
0. Thoát chương trình
Nhap lua chon: 2
Bạn thực hiện chức năng 2
Tổng số tiền lương công ty phải trả: 24,675,000 VNĐ""",
        "idea": """• Thiết kế mô hình kế thừa và đa hình (Inheritance & Polymorphism):
  - Lớp cơ sở NhanVien: Chứa MaNV, TenNV, các phương thức ảo (virtual) TinhLuong(), XuatThongTin(), ThemNV().
  - Lớp con NhanVienKinhDoanh: Kế thừa NhanVien, bổ sung LuongCoBan, SoHopDong. Ghi đè TinhLuong() = LuongCoBan + SoHopDong * 500,000.
  - Lớp con NhanVienSanXuat: Kế thừa NhanVien, bổ sung SoSanPham. Ghi đè TinhLuong() = SoSanPham * 1000 * (SoSanPham > 3000 ? 1.05 : 1.0).
  - Đa hình: Danh sách List<NhanVien> chứa hỗn hợp các đối tượng con. Khi duyệt danh sách tính lương hoặc xuất thông tin, chương trình tự động gọi đúng phương thức tương ứng của từng lớp con."""
    },

    # BÀI 3.6
    {
        "title": "Bài 3.6: Kế thừa và Đa hình - Tính điểm thí sinh",
        "folder": "bai18",
        "problem": """Phân tích, thiết kế và hiện thực theo hướng đối tượng chương trình tính điểm thi cho các thí sinh trong một cuộc thi tin học:
Cuộc thi dành cho hai đối tượng:
• Chuyên: Dành cho thí sinh chưa có giải trước đây. Làm 3 bài lập trình + 1 bài Tiếng Anh.
• Siêu cúp: Dành cho thí sinh đã đoạt giải trước đây. Làm 3 bài lập trình + 1 bài Cơ sở dữ liệu (CSDL).
Thông tin chung: SBD, Họ tên, Bai1, Bai2, Bai3, Tổng điểm.
Xét kết quả:
• Thí sinh Chuyên: Tổng 3 bài lập trình + điểm thưởng Tiếng Anh (7 <= Tiếng Anh <= 8: cộng 1 điểm; 9 <= Tiếng Anh <= 10: cộng 2 điểm).
• Thí sinh Siêu cúp: Tổng điểm của 4 bài thi (Bai1 + Bai2 + Bai3 + CSDL).
Yêu cầu: Viết chương trình nhập thông tin cuộc thi và xuất tổng điểm thi của từng thí sinh.""",
        "code_files": [
            {
                "filename": "bai18.cs",
                "content": read_file(os.path.join(base_dir, "bai18", "bai18.cs"))
            },
            {
                "filename": "Program.cs",
                "content": read_file(os.path.join(base_dir, "bai18", "Program.cs"))
            }
        ],
        "output": """Nhap so luong thi sinh: 2

--- NHAP THI SINH THU 1 ---
Nhap loai thi sinh (1: Chuyen, 2: Sieu Cup): 1
Nhap SBD: TS001
Nhap ho ten: Nguyen Van Chuyen
Nhap diem bai 1: 8
Nhap diem bai 2: 7.5
Nhap diem bai 3: 8.5
Nhap diem bai tieng anh: 9.5

--- NHAP THI SINH THU 2 ---
Nhap loai thi sinh (1: Chuyen, 2: Sieu Cup): 2
Nhap SBD: TS002
Nhap ho ten: Tran Van Sieu Cup
Nhap diem bai 1: 9
Nhap diem bai 2: 9.5
Nhap diem bai 3: 8
Nhap diem bai CSDL: 9

================ KET QUA TONG DIEM THI SINH ================
[Chuyen]   SBD: TS001 | Ho ten: Nguyen Van Chuyen | Tong diem: 26
[Sieu Cup] SBD: TS002 | Ho ten: Tran Van Sieu Cup | Tong diem: 35.5""",
        "idea": """• Thiết kế mô hình lớp với tính trừu tượng và đa hình:
  - Lớp trừu tượng (abstract class) ThiSinh: Chứa các thuộc tính chung (SBD, HoTen, Bai1, Bai2, Bai3) và phương thức trừu tượng public abstract double TinhTongDiem().
  - Lớp ThiSinhChuyen: Kế thừa ThiSinh, bổ sung thuộc tính TiengAnh, ghi đè TinhTongDiem() tính tổng 3 bài lập trình cộng điểm thưởng theo thang điểm tiếng Anh (cộng 1 điểm nếu 7..8, cộng 2 điểm nếu 9..10).
  - Lớp ThiSinhSieuCup: Kế thừa ThiSinh, bổ sung thuộc tính CSDL, ghi đè TinhTongDiem() tính tổng cả 4 bài thi.
  - Lớp CuocThi: Quản lý danh sách List<ThiSinh>, thể hiện tính đa hình khi gọi phương thức Xuat() và TinhTongDiem() tại thời điểm thực thi mà không phụ thuộc vào loại thí sinh cụ thể."""
    }
]

output_docx_path = os.path.join(base_dir, "BaoCao_ThucHanh02_CSharp.docx")
build_docx(output_docx_path, sections_data)
print("Complete successfully!")
