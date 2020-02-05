

function deleteTruck(idTruck) {
    swal({
        title: "Tem certeza?",
        text: "deseja realmente excluir?",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Sim, excluir!",
        closeOnConfirm: false
    },
    function () {
        $.ajax({
            url: '/Truck/Delete?idTruck=' + idTruck,
            type: 'GET',
            cache: false,
            success: function (response) {                
                swal("excluido!", "Caminhao excluido com sucesso!", "success");                
                location.reload(true);
            },
            error: function (error) {
                swal("Erro", "erro ao excluir", "warning");
            }
        });
    });
}