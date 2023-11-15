using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eAgendaMedica.Dominio.ModuloMedico
{
    public struct CRM 
    {

        private static long _counter;
        public CRM(byte[] b,string siglaEstado)
        {

        }
        public static CRM NewCRM(string estado)
        {
            byte[] array = Guid.NewGuid().ToByteArray();
            byte[] bytes = BitConverter.GetBytes(GetTicks());
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse((Array)bytes);
            }

            return new CRM(new byte[16]
            {
                array[0],
                array[1],
                array[2],
                array[3],
                array[4],
                array[5],
                array[6],
                array[7],
                bytes[1],
                bytes[0],
                bytes[7],
                bytes[6],
                bytes[5],
                bytes[4],
                bytes[3],
                bytes[2]
            },estado);
        }

        private static long GetTicks()
        {
            if (_counter == 0L)
            {
                _counter = DateTime.UtcNow.Ticks;
            }

            return Interlocked.Increment(ref _counter);
        }

    }
}
