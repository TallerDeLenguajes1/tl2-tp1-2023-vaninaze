using EspacioPedido;

Cadeteria cadeteria = new Cadeteria();
cadeteria.cargarCadeteria();

cadeteria.AltaPedido(1, 1, "sin cebolla", "Mar", "Junin 231", "32413", "porton verde");
cadeteria.AltaPedido(1, 2, "sin aji", "Luz", "Cordoba 829", "324849", "casa rosa");

cadeteria.AltaPedido(0, 1, "sin aji", "Luz", "Cordoba 829", "324849", "casa rosa");
cadeteria.AltaPedido(2, 1, "sin aji", "Luz", "Cordoba 829", "324849", "casa rosa");

cadeteria.Mostrar();

