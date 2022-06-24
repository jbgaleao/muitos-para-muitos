$(document).ready(function () {
    debugger;
    document.getElementById("btnAdd").addEventListener("click", function (event) {
        event.preventDefault()
    });
});

$(document).ready(function () {
    ProfessorFormCadstro_Load();

});

function ProfessorFormCadstro_Load() {
    var doc = $(document);
    doc.on("click", "#btnAdd", null, btnAdd_Click);
    doc.on("click", "#lstDisciplinas li", null, RemoveDisciplina);

};

function btnAdd_Click() {
    AdicionaDisciplina();
}

function AdicionaDisciplina() {
    debugger;
    var chkRptDisciplina = false;

    $('#lstDisciplinas li').each(function () {
        haveSomeLi = true;
        var current = $(this).text();
        if (current == $("#drop option:selected").text()) {
            chkRptDisciplina = true;
        }
    });

    if (!chkRptDisciplina) {
        $('#lstDisciplinas').append("<li>" + $("#drop option:selected").text() +
            "<input type='checkbox' name='chkDisciplina' id='chkDisciplina' class='chkDisciplina' checked='checked' value='" +
            $("#drop option:selected").val() + "'></li>");
    } else {
        alert("Disciplina Já inserida!");
    }
}

function RemoveDisciplina() {
    $('#lstDisciplinas').on('click', "li", function () {
        $(this).remove();
        return false;
    })
}