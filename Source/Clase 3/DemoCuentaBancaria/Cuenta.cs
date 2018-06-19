
namespace DemoCuentaBancaria
{
    class Cuenta
    {
        public string NombrePersona { get; set; }
        public string NroCuenta { get; set; }

        private double _saldo;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
        }

        public void Consignar(double valorAConsignar)
        {
            _saldo = _saldo + valorAConsignar - 10000;
        }


        public bool Retirar(double valorARetirar)
        {
            if (Saldo >= (valorARetirar + 4000))
            {
                _saldo = _saldo - valorARetirar - 4000;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}