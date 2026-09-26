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
			Bai22();
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
	}

}


