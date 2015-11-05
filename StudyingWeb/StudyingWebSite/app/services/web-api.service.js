if (typeof app !== 'undefined') {
    app
        .factory('WebServices', ['$resource', WebServices]);
}

WebServices.$inject = ['$resource'];

function WebServices($resource) {
    var apiUrl = '/api/';
    return {
        statisticTicketVisitTypes: $resource(apiUrl + 'thesaurus/statisticTicketVisitType', {},
        {
            query: { method: 'GET', params: { subdivisionId: '@subdivisionId', specialityNameId: '@specialityNameId' }, isArray: true },
        })
    }
};