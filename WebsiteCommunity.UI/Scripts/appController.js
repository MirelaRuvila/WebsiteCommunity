$(document).ready(function () {
    var _serviceContext = new ServiceContext();
    var _menuController = new MenuController(_serviceContext);
    _menuController.GenerateMenu();

});