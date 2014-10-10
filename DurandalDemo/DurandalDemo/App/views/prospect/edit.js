define(['knockout', 'plugins/router', 'komapping'], function (ko, router, map) {
    var vm = {
        activate: activate,
        error: ko.observable(),
        model: ko.observable(),
        name: ko.observable('Prospect'),
        save: saveNow,
        types: ko.observableArray(),
        NavBack: NavBack,
    };

    return vm;

    function enums(id) {
        $.ajax({
            type: 'get',
            url: '/api/prospect/prospecttype',
            success: function (d) {
                if (!!d.error) { console.log(d.message); }
                else {
                    console.log(d);
                    vm.types(d);
                    getProspect(id);
                }
            },
        });
    }

    function NavBack() {
        return router.navigateBack();
    }

    function saveNow(m, e) {
        var validator = $(e.target).closest(".form").kendoValidator().data("kendoValidator");
        if (validator.validate()) {
            $.ajax({
                type: 'put',
                url: '/api/prospect/',
                data: map.toJS(vm.model),
                success: function (d) {
                    if (!!d.error) { console.log(d.message); }
                    else {
                        console.log(d);
                        return router.navigateBack();
                    }
                },
            });
        }
    }

    function getProspect(id) {
        $.ajax({
            type: 'get',
            url: '/api/prospect/' + id,
            success: function (d) {
                if (!!d.error) { console.log(d.message); }
                else {
                    console.log(d);
                    vm.model(map.fromJS(d, {}));
                }
            },
        });
    }

    //#region Internal Methods
    function activate(id) {
        //add more dd like this.
        return enums(id);
    }
    //#endregion
});
