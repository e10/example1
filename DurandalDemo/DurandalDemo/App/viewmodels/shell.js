define(['plugins/router', 'durandal/app'], function (router, app) {
    return {
        router: router,
        search: function () {
            //It's really easy to show a message box.
            //You can add custom options too. Also, it returns a promise for the user's response.
            app.showMessage('Search not yet implemented...');
        },
        activate: function () {
            router.map([
                { route: '', moduleId: 'views/prospect/prospect', nav: true },
                { route: 'prospect/create', moduleId: 'views/prospect/create', nav: false },
                { route: 'prospect/edit/:id', moduleId: 'views/prospect/edit', nav: false },
            { route: 'prospect/delete/:id', moduleId: 'views/prospect/delete', nav: false }
            ]).buildNavigationModel();

            return router.activate();
        }
    };
});