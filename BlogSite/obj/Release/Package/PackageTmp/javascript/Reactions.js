
jQuery(document).ready(function ($) {
    //Carga Asincrona de Elementos
    $("#space_Questions").trigger("submit");
    $("#btnAjax").prop("disabled", true);

    $('#btnAjax').click(function ajaxCall() {
        var link = this;
        var dt = new Date();
        var question = document.getElementById("question").value;
        var idArticle = document.getElementById("idArticle").value;
        
        
        $('#btnAjax').val('Publicando...');
        $('#btnAjax').disabled = true;
            var QuestionData = {
                idQuestion: 0,
                idArticle: idArticle,
                Alias: "Secreto",
                Question: question,
                FechaCreacion: 'AMIGO',
                Creador: 'Secreto',
                fechaModificacion: dt,
                Modificador: 'Secreto'

            };

            $.ajax({
                url: "../../../Question/SaveQuestion",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(QuestionData),
                success: function (response) {
                    response ? $('#btnAjax').val('Excelente') : alert("Vaya, esto es bochornoso, lamentamos los inconvenientes :(");
                    var idQuestion = response.idQuestion;
                    $('#btnAjax').val('Agregado');
                   
                }
                  
            });
            AddQuestion();
    });

    function AddQuestion() {
        var question = document.getElementById("question").value;
        $("#rollReaction").prepend("<li><div class='timeline-image'>" +
                        "<img class='img-circle img-responsive' src='http://1.viki.io/d/1863c/8b75dc48c9.gif' alt=''></div>" +
                        "<div class='timeline-panel'>" +
                        "<div class='timeline-heading'>" +
                        "<h4>Creado Por</h4>" +
                        "<h4 class='subheading'>Secreto</h4></div>" +
                        "<div class='timeline-body'>" +
                        "<p class='text-muted'>" +
                        question +
                        "</p></div></div>" +
                        " <div class='line'></div>" +
                        "</li>"
        );
        $("#btnAjax").prop("disabled", true);
        $("#question").val('');
    }


    $('#question').bind('input propertychange', function () {
        var text = $(this).val();
        var textLength = text.length;

        if (text.length > 4) {
            $("#btnAjax").prop("disabled", false);
        }
        else {
            $("#btnAjax").prop("disabled", true);
        }
    });


});

