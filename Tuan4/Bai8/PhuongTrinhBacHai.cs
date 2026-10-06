namespace Bai8
{
    public class PhuongTrinhBacHai
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public PhuongTrinhBacHai(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public string GiaiPhuongTrinhBacNhat()
        {
            if (A == 0)
            {
                return B == 0
                    ? "Phương trình có vô số nghiệm."
                    : "Phương trình vô nghiệm.";
            }

            double x = -B / A;
            return $"Phương trình có nghiệm x = {x}";
        }

        public string GiaiPhuongTrinhBacHai()
        {
            if (A == 0)
                return GiaiPhuongTrinhBacNhat();

            double delta = B * B - 4 * A * C;
            if (delta < 0)
                return "Phương trình vô nghiệm.";

            if (delta == 0)
            {
                double x = -B / (2 * A);
                return $"Phương trình có nghiệm kép x = {x}";
            }

            double canDelta = Math.Sqrt(delta);
            double x1 = (-B + canDelta) / (2 * A);
            double x2 = (-B - canDelta) / (2 * A);
            return $"Phương trình có hai nghiệm: x1 = {x1}, x2 = {x2}";
        }
    }
}
