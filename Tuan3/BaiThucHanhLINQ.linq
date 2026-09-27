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
			Bai41();
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
	}

}


