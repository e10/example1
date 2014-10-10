requirejs.config({
    paths: {
        'text': '../Scripts/text',
        'durandal': '../Scripts/durandal',
        'plugins': '../Scripts/durandal/plugins',
        'transitions': '../Scripts/durandal/transitions',
        'knockout': '../Scripts/knockout-3.1.0',
        'jquery': '../Scripts/jquery-1.9.1',
        'komapping': '../scripts/knockout.mapping-latest',
        'plugins': '../scripts/durandal/plugins',
        'kendo': '../scripts/kendo.all.min'
    },
    shim: {
        'jqueryui': {
            exports: "$.ui",
            deps: ['jquery']
        },
        "underscore": {
            exports: "_"
        },
        'underscore-string': {
            deps: ['underscore'],
            exports: '_s'
        },
        'komapping': {
            deps: ['knockout'],
            exports: 'ko.mapping'
        },
        'knockout.kendo': {
            deps: ['knockout'],
            exports: 'knockout-kendo.min'
        }
    }
});




define(['durandal/system', 'durandal/app', 'durandal/viewLocator', 'kendo', 'durandal/binder', 'knockout', 'jquery'], function (system, app, viewLocator, kendo, binder, ko, $) {
    //>>excludeStart("build", true);
    system.debug(true);
    //>>excludeEnd("build");

    app.title = 'Durandal Starter Kit';

    app.configurePlugins({
        router: true,
        dialog: true
    });

    app.start().then(function() {
        //Replace 'viewmodels' in the moduleId with 'views' to locate the view.
        //Look for partial views in a 'views' folder in the root.
        viewLocator.useConvention();
        kendo.ns = "k-";


        //should be only loaded after native binding is loaded.
        binder.bindingComplete = function (obj, view) {
            kendo.bind(view, obj.viewModel || obj);
        };
        //Show the app by setting the root view model for our application with a transition.
        app.setRoot('viewmodels/shell', 'entrance');
    });
});