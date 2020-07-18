$(function () {
    var cy = window.cy = cytoscape({
        container: document.getElementById('cy'),
        boxSelectionEnabled: false,
        autounselectify: true,
        layout: {
            name: 'dagre'
            //fit: true
        },
        style: [
            {
                selector: 'node',
                style: {
                    'content': 'data(id)',
                    'text-opacity': 0.8,
                    'text-valign': 'center',
                    'color': 'white',
                    'width': 120,
                    'height': 30,
                    //'text-halign': 'top',
                    'background-color': '#11479e'
                    //'background-color': 'green',
                }
            },
            {
                selector: 'edge',
                style: {
                    'width': 2,
                    //'target-arrow-shape': 'triangle',
                    'line-color': '#9dbaea',
                    //'target-arrow-color': '#9dbaea',
                    'curve-style': 'bezier',
                    'content': 'data(weight)'
                }
            }
        ],
        elements: {
            nodes: [

                { data: { id: 'Baltimore' } },
                { data: { id: 'Buffalo' } },
                { data: { id: 'Cincinatti' } },
                { data: { id: 'Cleveland' } },
                { data: { id: 'Detroit' } },
                { data: { id: 'New York' } },
                { data: { id: 'Philadelphia' } },
                { data: { id: 'Pittsburgh' } },
                { data: { id: 'Washington' } }
            ],
            edges: [
                { data: { source: 'Washington', target: 'Baltimore', weight: 39 } },
                { data: { source: 'Philadelphia', target: 'New York', weight: 92 } },
                { data: { source: 'Philadelphia', target: 'Baltimore', weight: 97 } },
                { data: { source: 'Pittsburgh', target: 'Cleveland', weight: 125 } },
                { data: { source: 'Detroit', target: 'Cleveland', weight: 167 } },
                { data: { source: 'Cleveland', target: 'Buffalo', weight: 186 } },
                { data: { source: 'Pittsburgh', target: 'Baltimore', weight: 230 } },
                { data: { source: 'Cleveland', target: 'Cincinatti', weight: 244 } }

                //{ data: { source: 'Detroit', target: 'Buffalo', weight: 252 } },
                //{ data: { source: 'Detroit', target: 'Cincinatti', weight: 265 } },
                //{ data: { source: 'Pittsburgh', target: 'Cincinatti', weight: 284 } },
                //{ data: { source: 'Pittsburgh', target: 'Philadelphia', weight: 305 } },
                //{ data: { source: 'Buffalo', target: 'Baltimore', weight: 345 } },
                //{ data: { source: 'Philadelphia', target: 'Buffalo', weight: 365 } },
                //{ data: { source: 'Pittsburgh', target: 'New York', weight: 386 } },
                //{ data: { source: 'New York', target: 'Buffalo', weight: 445 } },
                //{ data: { source: 'Washington', target: 'Cincinatti', weight: 492 } },
                //{ data: { source: 'New York', target: 'Cleveland', weight: 507 } }
            ]
        }
    });
});
