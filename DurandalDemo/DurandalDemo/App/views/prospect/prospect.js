define(['knockout', 'kendo'], function (ko, kendo) {
    var vm = {
        activate:activate,
        source:new kendo.data.DataSource({
            parameterMap: function (options) { var paramMap = kendo.data.transports.odata.parameterMap(options); delete paramMap.format; return paramMap; },
            schema: { data: function (data) { return data.Items; }, total: function (data) { return data.Count; } },
            pageSize: 20, serverPaging: true, serverFiltering: true, serverSorting: true,
            sort: { field: "ProspectName", dir: "asc" },
            type: 'odata',
            transport: {
                read: { url: '/api/prospect', dataType: "json" }
            },
        })
    }

    return vm;

    function activate() {
        vm.source.fetch();
        return true;
    }
});





