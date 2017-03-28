//Salvar tarefa
$(GenerallSettings.BtnSave).click(function () {

    var task = {
        Description: $(GenerallSettings.Description).val()
    }

    if ($(GenerallSettings.Description).val() != "") {
        $.ajax({
            url: Url.NewTask,
            dataType: "json",
            method: "POST",
            data: {
                newTask: task
            },
            success: function (data) {
                alert("Sua tarefa foi adicionada com sucesso!");
                location.reload();
            },
            error: function (data) {
                alert("Ops, não foi possível salvar sua tarefa!" + data.statusText);
            },
            beforeSend: function () {
                $(GenerallSettings.BtnSave).css({ display: "disable" });
            },
            complete: function () {
                $(GenerallSettings.BtnSave).css({ display: "none" });
            }
        });
    }
    else {
        alert("Favor preencher a descrição da tarefa!");
    }
});

//Editar status datarefa
var id = 0;
function changeTask(id) {
    var task = {
        IdTask: id
    }

    if (id != 0)
    {
        $.ajax({
            url: Url.EditTask,
            dataType: "json",
            method: "POST",
            data: {
                editTask: task
            },
            success: function (data) {
                alert("Estado atualizado com sucesso!");
                location.reload();
            },
            error: function (data) {
                alert("Ops, não foi possível atualizar o estado! \nErro: " + data.statusText);
            }
        })
    }
    else {
        alert("Task inválida");
    }
   
};


