$(document).ready(function () {
    var table = $('#datatable').DataTable({
        language: {
            "url": '//cdn.datatables.net/plug-ins/1.13.5/i18n/es-ES.json',
        },
        lengthMenu: [
            10, 30, 50, 100
        ],
        columnDefs: [
            {
                orderable: false, targets: [0, 2]
            }
        ]
    });

    // Crear instancia de los botones
    var buttons = new $.fn.dataTable.Buttons(table, {
        buttons: [
            {
                extend: 'copy',
                text: '<i class="bi bi-file-earmark-break d-block d-lg-none"></i><span class= "mx-1 d-none d-lg-block">Copiar</span>',
                className: 'd-flex align-items-center btn btn-outline-primary mx-1',
                titleAttr: 'Copiar',
            },
            {
                extend: 'excel',
                text: '<i class="bi bi-file-excel d-block d-lg-none"></i><span class= "mx-1 d-none d-lg-block">Excel</span>',
                className: 'd-flex align-items-center btn btn-outline-primary mx-1',
                titleAttr: 'Excel',
            },
            {
                extend: 'pdf',
                text: '<i class="bi bi-file-earmark-pdf d-block d-lg-none"></i><span class= "mx-1 d-none d-lg-block">PDF</span>',
                className: 'd-flex align-items-center btn btn-outline-primary mx-1',
                titleAttr: 'PDF',
                exportOptions: {
                    columns: ':not(.no-export)' // Agrega la clase 'no-export' a las columnas que no deseas exportar
                }
            },
            {
                extend: 'print',
                text: '<i class="bi bi-printer d-block d-lg-none"></i><span class= "mx-1 d-none d-lg-block">Imprimir</span>',
                className: 'd-flex align-items-center btn btn-outline-primary mx-1',
                titleAttr: 'Imprimir'
            },
            {
                extend: 'colvis',
                className: 'd-flex align-items-center btn btn-outline-primary mx-1',
                text: 'Columnas Visibles',
            }
        ]

    });

    // Obtener el contenedor de botones
    var container = buttons.container();

    container.removeClass('btn-group dt-buttons flex-wrap').addClass('d-flex');
    // Agregar clases personalizadas a los botones
    container.find('button').each(function () {
        $(this).removeClass('btn-secondary'); // Agrega tus clases personalizadas aquí
    });

    // Agregar los botones al contenedor personalizado
    container.appendTo($('#container-buttons .dt-buttons'));
});