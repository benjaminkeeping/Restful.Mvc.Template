The project Restful.Mvc.Template is (obviously !) your MVC site

The solution has 3 other projects in it, to simplify the example (but they'd probably be in a different solution realistically)

The project Example.Service.Client.Mvc is what you expose directly to your MVC layer.
The project Example.Service.Client is where you would do your *actual* calls to your service layer.
The project  Example.Service.Wiretypes is the shared wiretypes between your MVC layer, clients and service layer (ie OpenRasta)


