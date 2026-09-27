<Query Kind="Program">
  <Connection>
    <ID>d6575ffa-e754-4c70-9f33-47aa7bf34f5d</ID>
    <NamingServiceVersion>3</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <UseMicrosoftDataSqlClient>true</UseMicrosoftDataSqlClient>
    <EncryptTraffic>true</EncryptTraffic>
    <Database>QuanLyBanHang</Database>
    <MapXmlToString>false</MapXmlToString>
    <DriverData>
      <SkipCertificateCheck>true</SkipCertificateCheck>
    </DriverData>
  </Connection>
  <Output>DataGrids</Output>
  <AutoDumpHeading>true</AutoDumpHeading>
</Query>

using System;
using System.Collections.Generic;
using System.Linq;
namespace BaiThucHanhLINQ
{
	class Program
	{
		static void Main()
		{
			//Bai21();
			//Bai22();
			//Bai31();
			//Bai32();
			//Bai41();
			//Bai51();
			//Bai52();
			//Bai61();
			Bai62();
		}
		
		static void Bai21()
		{
			int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };
			
			mangSo.Dump("-------------Bai 2.1) mang ban dau: --------------");
			
			
			var kq = from n in mangSo
						where n % 4 ==0 && n % 3 ==0
						select n;
			kq.Dump("-------------Bai 2.1.a) mang ket qua sau truy van chia het cho 4 va 3: --------------");
			
			
			kq = from n in mangSo
						where n <= 3
						select n;
			kq.Dump("-------------Bai 2.1.b) mang ket qua sau khi truy van so nho hon hoac bang 3: --------------");
			
			int[] KetQua = null;
			
			kq = from n in mangSo
					select n % 2 == 0? n/2: n;
			
			kq.Dump("-------------Bai 2.1.c) mang ket qua sau khi truy van so chan chia doi so le giu nguyen: --------------");
		}
		
		static void Bai22()
		{
			string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga","Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };
			
			
			var kqA = mangChuoi.Where(w => w.Length == 4).OrderBy(w=>w[0]);
			kqA.Dump("-------------Bai 2.2.a) mang ket qua sau khi truy van liet ke phan tu co 4 ky tu va xap xep tang dan theo ky tu dau tien.: --------------");
			
			
			var kqB = from w in mangChuoi
					select $"{w.ToLower()} - {w.ToUpper()}";
			kqB.Dump("-------------Bai 2.2.b) mang ket qua sau khi truy van de chuyen format thanh toLower - toUpper: --------------");
			
			var kqC = from w in mangChuoi
						where w.ToLower().Contains("u")
						select w;
			kqC.Dump("-------------Bai 2.2.c) mang ket qua sau khi truy van tim tu chua u: --------------");
			
			
			var kqD = from w in mangChuoi
						where !string.IsNullOrEmpty(w) && char.IsUpper(w[0])
						select w;
			kqD.Dump("-------------Bai 2.2.d) mang ket qua sau khi truy van tim tu co chu cai dau in hoa: --------------");
		}
		
		static void Bai31()
		{
			int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };
			
			var kqA_1 = mangSo.Length;
			kqA_1.Dump("-------------Bai 3.1.a) so phan tu cua mang: --------------");
			
			var kqA_2 = (from n in mangSo
							where n %2 == 0
							select n).Count();
			kqA_2.Dump("-------------Bai 3.1.b) so phan tu chan cua mang: --------------");
			
			var kqA_3 = (from n in mangSo
							where n %2 != 0
							select n).Count();
			kqA_3.Dump("-------------Bai 3.1.c) so phan tu le cua mang: --------------");
			
			
			// 1. Tính tổng các giá trị
			var kqB_Tong = mangSo.Sum();
			kqB_Tong.Dump("-------------Bai 3.1.b1) Tong cac gia tri trong mang: --------------");
			
			// 2. Tìm giá trị lớn nhất
			var kqB_Max = mangSo.Max();
			kqB_Max.Dump("-------------Bai 3.1.b2) Gia tri lon nhat: --------------");
			
			// 3. Tìm giá trị nhỏ nhất
			var kqB_Min = mangSo.Min();
			kqB_Min.Dump("-------------Bai 3.1.b3) Gia tri nho nhat: --------------");
			
			
			
			var kqC = mangSo.Distinct().Count();
			kqC.Dump("-------------Bai 3.1.c) So gia tri khac nhau trong mang: --------------");
			
			
			var kqD = from n in mangSo
	          group n by n % 5 into g
	          select new { 
	              SoDu = g.Key, 
	              CacPhanTu = string.Join(", ", g) 
	          };

			kqD.Dump("-------------Bai 3.1.d) Phan nhom theo so du khi chia cho 5: --------------");
		}
		
		static void Bai32()
		{
			string[] monAn = { "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
				"Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào",
				"Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" };
				
			// a)
			
			int doDaiNganNhat = monAn.Min(s => s.Length);
			int doDaiDaiNhat = monAn.Max(s => s.Length);
			
			var kqA_1 = monAn.Where(s => s.Length == doDaiNganNhat);
			kqA_1.Dump($"-------------Bai 3.2.a) Mon an ngan nhat ({doDaiNganNhat} ky tu): --------------");
			
			var kqA_2 = monAn.Where(s => s.Length == doDaiDaiNhat);
			kqA_2.Dump($"-------------Bai 3.2.a) Mon an dai nhat ({doDaiDaiNhat} ky tu): --------------");
			
			
			
			var kqB = from monan in monAn
			         group monan by monan.Split(' ')[0] into tu
			         select new { 
			             TuDauTien = tu.Key, 
			             CacMonAn = string.Join(", ", tu) 
			         };
			
			kqB.Dump("-------------Bai 3.2.b) Phan nhom theo tu dau tien: --------------");
			
			var kqC = from monan in monAn
						group monan by monan.Split(' ')[0] into tu
						where tu.Key == "Bánh"
						select tu.Count();
						
			kqC.Dump("-------------Bai 3.2.c) So tu bat dau bang 'Banh': --------------");
		
		}
		
		
		
		public class MonHoc
			{
			    public string MaMon { get; set; } = "";
			    public string TenMon { get; set; } = "";
			    public string He { get; set; } = "";
			    public byte SoTiet { get; set; }
			}
		
		public class DuLieu
			{
			    public static List<MonHoc> DS_Mon()
			    {
			        return new List<MonHoc>
			        {
			            new MonHoc { MaMon = "HP2_1", TenMon = "Nền tảng C#", He = "KTV", SoTiet = 64 },
			            new MonHoc { MaMon = "HP2_2", TenMon = "Công nghệ ADO.NET", He = "KTV", SoTiet = 64 },
			            new MonHoc { MaMon = "HP3_1", TenMon = "Lập trình Windows Forms", He = "KTV", SoTiet = 64 },
			            new MonHoc { MaMon = "HP3_2", TenMon = "Xây dựng ứng dụng Windows Forms", He = "KTV", SoTiet = 64 },
			            new MonHoc { MaMon = "HP4_1", TenMon = "Lập trình Web với HTML, CSS và JavaScript", He = "KTV", SoTiet = 64 },
			            new MonHoc { MaMon = "HP4_2", TenMon = "Xây dựng ứng dụng Web với ASP.NET", He = "KTV", SoTiet = 64 },
			            new MonHoc { MaMon = "HP5_1", TenMon = "Lập trình CSDL SQL Server căn bản", He = "KTV", SoTiet = 64 },
			            new MonHoc { MaMon = "HP5_2", TenMon = "Lập trình CSDL SQL Server nâng cao", He = "KTV", SoTiet = 64 },
			            new MonHoc { MaMon = "JLCB",  TenMon = "Joomla cơ bản", He = "CD", SoTiet = 72 },
			            new MonHoc { MaMon = "LINQ",  TenMon = "Language-Integrated Query", He = "CD", SoTiet = 64 },
			            new MonHoc { MaMon = "DAWEB", TenMon = "Đồ án thực tế Web với ASP.NET", He = "CD", SoTiet = 40 },
			            new MonHoc { MaMon = "DAWIN", TenMon = "Đồ án thực tế Windows Forms", He = "CD", SoTiet = 40 },
			            new MonHoc { MaMon = "CC++",  TenMon = "Lập trình hướng đối tượng với C/C++", He = "CD", SoTiet = 128 },
			            new MonHoc { MaMon = "JQUE",  TenMon = "JQuery", He = "CD", SoTiet = 22 },
			            new MonHoc { MaMon = "XML",   TenMon = "Công nghệ XML", He = "CD", SoTiet = 32 },
			            new MonHoc { MaMon = "CRYS",  TenMon = "Crystal Report trong Visual Studio", He = "CD", SoTiet = 32 },
			            new MonHoc { MaMon = "BWEB",  TenMon = "HTML, CSS và JavaScript", He = "CD", SoTiet = 32 },
			            new MonHoc { MaMon = "XYZ",   TenMon = "Chưa đặt tên môn", He = "", SoTiet = 0 }
			        };
			    }
			}
		
		static void Bai41()
		{
			var DsMonHoc = DuLieu.DS_Mon();
			DsMonHoc.Dump();
		}
		
		
		static void Bai51()
		{
			var DsMonHoc = DuLieu.DS_Mon();
			
			var kqA = from m in DsMonHoc
						where m.TenMon.StartsWith("Lập trình")
						select m;
			
			kqA.Dump("-------------Bai 5.1.a) Truy van ten mon hoc bat dau tu 'Lap trinh': --------------");
			
			
			var kqB = from m in DsMonHoc
			         where m.He == "CD"
			         orderby m.SoTiet descending, m.MaMon ascending
			         select m;
			
			kqB.Dump("-------------Bai 5.1.b) truy van mon hoc he 'CD' co so tiet giam dan va ma nhon tang dan: --------------");
			
			
			var kqC = from m in DsMonHoc
			         where m.TenMon.ToLower().Contains("web")
			         select new { 
			             TenMon = m.TenMon, 
			             He = m.He 
			         };
			
			kqC.Dump("-------------Bai 5.1.c) Cac mon co ten chua tu 'web' (chi lay ten mon va he): --------------");
			
			
			var kqD = from m in DsMonHoc
			         where m.He == "KTV"
			         orderby m.MaMon ascending
			         select m;
			
			kqD.Dump("-------------Bai 5.1.d) Cac mon thuoc he 'KTV' (sap xep theo ma mon tang dan): --------------");
		}
		
		static void Bai52()
		{
			var dsMon = DuLieu.DS_Mon();

			// a. Cho biết tổng số môn hiện có.
			var kqA = dsMon.Count();
			kqA.Dump("-------------Bai 5.2.a) Tong so mon hien co: --------------");
		
			// b. Đếm số môn có tên bắt đầu bằng “Lập trình”.
			var kqB = dsMon.Count(m => m.TenMon.StartsWith("Lập trình"));
			kqB.Dump("-------------Bai 5.2.b) So mon co ten bat dau bang 'Lap trinh': --------------");
		
			// c. Tính tổng số tiết của hệ Kỹ thuật viên (KTV).
			var kqC = dsMon.Where(m => m.He == "KTV").Sum(m => (int)m.SoTiet);
			kqC.Dump("-------------Bai 5.2.c) Tong so tiet cua he KTV: --------------");
		
			// d. Cho biết tổng số môn của mỗi hệ: Hệ, Tổng số môn.
			var kqD = dsMon.GroupBy(m => string.IsNullOrEmpty(m.He) ? "Khác" : m.He)
						   .Select(g => new { 
							   He = g.Key, 
							   TongSoMon = g.Count() 
						   });
			kqD.Dump("-------------Bai 5.2.d) Tong so mon cua moi he: --------------");
		
			// e. Nhóm theo Số tiết; in Số tiết và Tổng số môn, sắp xếp giảm dần theo Số tiết.
			var kqE = dsMon.GroupBy(m => m.SoTiet)
						   .OrderByDescending(g => g.Key)
						   .Select(g => new { 
							   SoTiet = g.Key, 
							   TongSoMon = g.Count() 
						   });
			kqE.Dump("-------------Bai 5.2.e) Nhom theo So tiet (sap xep giam dan theo So tiet): --------------");
		
			// f. Cho biết thông tin môn học có số tiết cao nhất.
			byte maxSoTiet = dsMon.Max(m => m.SoTiet);
			var kqF = dsMon.Where(m => m.SoTiet == maxSoTiet);
			kqF.Dump("-------------Bai 5.2.f) Thong tin mon hoc co so tiet cao nhat: --------------");
		
			// g. Thống kê theo Hệ: tổng số môn, tổng số tiết, số tiết cao nhất, số tiết thấp nhất.
			var kqG = dsMon.GroupBy(m => string.IsNullOrEmpty(m.He) ? "Khác" : m.He)
						   .Select(g => new { 
							   He = g.Key, 
							   TongSoMon = g.Count(), 
							   TongSoTiet = g.Sum(m => (int)m.SoTiet),
							   SoTietCaoNhat = g.Max(m => m.SoTiet),
							   SoTietThapNhat = g.Min(m => m.SoTiet)
						   });
			kqG.Dump("-------------Bai 5.2.g) Thong ke theo He: --------------");
		
			// h. Liệt kê các môn học được phân nhóm theo Hệ.
			var kqH = dsMon.GroupBy(m => string.IsNullOrEmpty(m.He) ? "Khác" : m.He)
						   .Select(g => new { 
							   He = g.Key, 
							   CacMonHoc = string.Join(", ", g.Select(m => m.TenMon)) 
						   });
			kqH.Dump("-------------Bai 5.2.h) Liet ke cac mon hoc phan nhom theo He: --------------");
		
			// i. Liệt kê các môn học được phân nhóm theo Số tiết và tăng dần theo Số tiết.
			var kqI = dsMon.GroupBy(m => m.SoTiet)
						   .OrderBy(g => g.Key)
						   .Select(g => new { 
							   SoTiet = g.Key, 
							   CacMonHoc = string.Join(", ", g.Select(m => m.TenMon)) 
						   });
			kqI.Dump("-------------Bai 5.2.i) Liet ke cac mon hoc phan nhom theo So tiet (tang dan): --------------");
		
			// j. Với hệ KTV, phân nhóm theo học phần HP2, HP3, HP4, HP5; sắp xếp theo Mã môn.
			var kqJ = dsMon.Where(m => m.He == "KTV")
						   .GroupBy(m => m.MaMon.Split('_')[0])
						   .OrderBy(g => g.Key)
						   .Select(g => new { 
							   HocPhan = g.Key, 
							   CacMonHoc = string.Join(", ", g.OrderBy(m => m.MaMon).Select(m => $"{m.MaMon}: {m.TenMon}")) 
						   });
			kqJ.Dump("-------------Bai 5.2.j) He KTV phan nhom theo hoc phan (sap xep theo Ma mon): --------------");
		
			// k. Phân nhóm theo Hệ, chỉ lấy các môn có Số tiết > 40; trong mỗi nhóm sắp xếp theo Mã môn.
			var kqK = dsMon.Where(m => m.SoTiet > 40)
						   .GroupBy(m => string.IsNullOrEmpty(m.He) ? "Khác" : m.He)
						   .Select(g => new { 
							   He = g.Key, 
							   CacMonHoc = string.Join(", ", g.OrderBy(m => m.MaMon).Select(m => $"{m.MaMon}: {m.TenMon} ({m.SoTiet} tiết)")) 
						   });
			kqK.Dump("-------------Bai 5.2.k) Phan nhom theo He (So tiet > 40, sap xep theo Ma mon): --------------");
		}
		
		
		
		public class He
		{
		    public string MaHe { get; set; } = "";
		    public string TenHe { get; set; } = "";
		}
		
		public class DuLieu_He
		{
		    public static List<He> DS_He()
		    {
		        return new List<He>
		        {
		            new He { MaHe = "KTV", TenHe = "Kỹ thuật viên" },
		            new He { MaHe = "CD",  TenHe = "Chuyên đề" },
		            new He { MaHe = "QT",  TenHe = "Chứng chỉ quốc tế" }
		        };
		    }
		}
		
		
		static void Bai61()
		{
			var dsHe = DuLieu_He.DS_He();
			dsHe.Dump("------------- Danh sách Hệ đào tạo -------------");
		}
		
		static void Bai62()
		{
			var dsMon = DuLieu.DS_Mon();
			var dsHe = DuLieu_He.DS_He();
		
			// a. Dùng join để liệt kê: Tên hệ, Mã môn, Tên môn.
			var kqA = from h in dsHe
					   join m in dsMon on h.MaHe equals m.He
					   select new {
						   TenHe = h.TenHe,
						   MaMon = m.MaMon,
						   TenMon = m.TenMon
					   };
			kqA.Dump("-------------Bai 6.2.a) Liet ke Bang Inner Join (Ten he, Ma mon, Ten mon): --------------");
		
			// b. Liệt kê cả những hệ chưa có môn học (Left Outer Join với GroupJoin + DefaultIfEmpty).
			var kqB = from h in dsHe
					   join m in dsMon on h.MaHe equals m.He into gj
					   from subMon in gj.DefaultIfEmpty()
					   select new {
						   TenHe = h.TenHe,
						   MaMon = subMon?.MaMon ?? "(Chưa có)",
						   TenMon = subMon?.TenMon ?? "(Chưa có)"
					   };
			kqB.Dump("-------------Bai 6.2.b) Left Outer Join (Liet ke ca he chua co mon hoc): --------------");
		
			// c. Liệt kê cả hệ chưa có môn học và môn học chưa khai báo hệ (Full Outer Join).
			var leftJoin = from h in dsHe
						    join m in dsMon on h.MaHe equals m.He into gj
						    from subMon in gj.DefaultIfEmpty()
						    select new {
							    TenHe = h.TenHe,
							    MaMon = subMon?.MaMon ?? "(Chưa có)",
							    TenMon = subMon?.TenMon ?? "(Chưa có)"
						    };
		
			var rightOnly = from m in dsMon
						     where !dsHe.Any(h => h.MaHe == m.He)
						     select new {
							     TenHe = "(Chưa khai báo)",
							     MaMon = m.MaMon,
							     TenMon = m.TenMon
						     };
		
			var kqC = leftJoin.Concat(rightOnly);
			kqC.Dump("-------------Bai 6.2.c) Full Outer Join (Cả hệ chưa có môn và môn chưa có hệ): --------------");
		
			// d. Chỉ liệt kê những hệ chưa có môn học và những môn học chưa khai báo hệ.
			var heChuaCoMon = from h in dsHe
							   where !dsMon.Any(m => m.He == h.MaHe)
							   select new {
								   TenHe = h.TenHe,
								   MaMon = "(Không có)",
								   TenMon = "(Không có)",
								   GhiChu = "Hệ chưa có môn học"
							   };
		
			var monChuaCoHe = from m in dsMon
							   where !dsHe.Any(h => h.MaHe == m.He)
							   select new {
								   TenHe = "(Chưa khai báo)",
								   MaMon = m.MaMon,
								   TenMon = m.TenMon,
								   GhiChu = "Môn học chưa khai báo hệ"
							   };
		
			var kqD = heChuaCoMon.Concat(monChuaCoHe);
			kqD.Dump("-------------Bai 6.2.d) Chi liet ke he chua co mon va mon chua khai bao he: --------------");
		
			// e. Lấy 5 môn học đầu tiên có số tiết giảm dần; hiển thị Tên hệ, Mã môn, Tên môn, Số tiết.
			var kqE = (from m in dsMon
					   join h in dsHe on m.He equals h.MaHe into gj
					   from subHe in gj.DefaultIfEmpty()
					   orderby m.SoTiet descending
					   select new {
						   TenHe = subHe?.TenHe ?? "(Chưa khai báo)",
						   MaMon = m.MaMon,
						   TenMon = m.TenMon,
						   SoTiet = m.SoTiet
					   }).Take(5);
			kqE.Dump("-------------Bai 6.2.e) Top 5 mon hoc co so tiet giam dan: --------------");
		
			// f. Cho biết tổng số môn học của mỗi hệ: Mã hệ, Tên hệ, Tổng số môn.
			var kqF = from h in dsHe
					   join m in dsMon on h.MaHe equals m.He into gj
					   select new {
						   MaHe = h.MaHe,
						   TenHe = h.TenHe,
						   TongSoMon = gj.Count()
					   };
			kqF.Dump("-------------Bai 6.2.f) Tong so mon hoc cua moi he: --------------");
		
			// g. Cho biết có bao nhiêu loại Số tiết khác nhau trong danh sách môn học.
			var kqG = dsMon.Select(m => m.SoTiet).Distinct().Count();
			kqG.Dump("-------------Bai 6.2.g) So loai So tiet khac nhau: --------------");
		
			// h. Tìm môn học đầu tiên có tên bắt đầu bằng “Lập trình”.
			var kqH = dsMon.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình"));
			kqH.Dump("-------------Bai 6.2.h) Mon hoc dau tien co ten bat dau bang 'Lap trinh': --------------");
		
			// i. Liệt kê các môn theo từng hệ, đánh số thứ tự trong mỗi nhóm.
			var kqI = from h in dsHe
					   join m in dsMon on h.MaHe equals m.He into gj
					   select new {
						   TenHe = h.TenHe,
						   DanhSachMon = gj.Select((m, index) => new {
							   STT = index + 1,
							   MaMon = m.MaMon,
							   TenMon = m.TenMon,
							   SoTiet = m.SoTiet
						   })
					   };
			kqI.Dump("-------------Bai 6.2.i) Liet ke cac mon theo tung he (co danh STT): --------------");
		}
	}

}


