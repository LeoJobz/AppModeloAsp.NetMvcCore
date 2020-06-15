using DevIOUI.Site.Models;
using static DevIOUI.Site.Data.PedidoRepository;

namespace DevIOUI.Site.Data
{
    public class PedidoRepository : IPedidoRepository
    {
        public Pedido ObterPedido()
        {
            return new Pedido();
        }

        public interface IPedidoRepository
        {
            Pedido ObterPedido();
        }
    }
}
