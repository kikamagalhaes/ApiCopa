using apideteste.models;
using System.Collections.Generic;

namespace apideteste.Services
{
    public class SingletonCliente
    {
        private SingletonCliente() { }

        private static SingletonCliente instance;

        private List<Cliente> clientes = new List<Cliente>();

        public List<Cliente> Clientes()
        {
            return clientes;
        }

        public void Add(Cliente cliente)
        {
            clientes.Add(cliente) ;
        }
        public static SingletonCliente Instance()
        {
            if(instance == null)
            { 
              instance = new SingletonCliente();
            }
            return instance;
        }
    }
}
