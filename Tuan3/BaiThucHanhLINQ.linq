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
			Bai31();
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
	}

}


