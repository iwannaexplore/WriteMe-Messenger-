;
const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/chat")
    .build();


hubConnection.serverTimeoutMilliseconds = 1000 * 60 * 10;

hubConnection.on('Receive',
    function (message, userName) {
        if (userName == $("#friend").val()) {
            var companionMessage = $("<div class='companion-message'></div>");
            $(companionMessage).text(message);

            var companionBlock = $("<div class='messages'></div>");
            $(companionBlock).append(companionMessage);
            $("#chat").append(companionBlock);
        } else if (userName == $("#current").val()) {
            var userMessage = $("<div class='my-message-text'></div>");
            $(userMessage).text(message);

            var userBlock = $("<div class='messages my-message'></div>");
            $(userBlock).append(userMessage);
            $("#chat").append(userBlock);
        }

        document.querySelector("#chat").scrollTop = document.querySelector("#chat").scrollHeight;
    });
hubConnection.on('UploadFile',
    (data, userName, file, format) => {
        if (format == "image") {
            if (userName == $("#friend").val()) {
                var companionMessage = $(`<a href="/messageImages/${file}" target="_blank"><img src="/messageImages/` +
                    data +
                    '" class="companion-file-message"></a>');

                var companionBlock = $("<div class='messages'></div>");
                $(companionBlock).append(companionMessage);
                $("#chat").append(companionBlock);
            } else if (userName == $("#current").val()) {
                var userMessage = $(`<a href="/messageImages/${file}" target="_blank"><img src="/messageImages/` +
                    data +
                    '" class="my-file-message"></a>');

                var userBlock = $("<div class='messages my-message'></div>");
                $(userBlock).append(userMessage);
                $("#chat").append(userBlock);
            }

            document.querySelector("#chat").scrollTop = document.querySelector("#chat").scrollHeight;
            return;
        }
        if (format == "video") {
            if (userName == $("#friend").val()) {
                var companionMessage = $(`<video width="320" height="240" class="my-file-message" controls>
  <source src="/messageVideos/${file}">
</video>`);

                var companionBlock = $("<div class='messages'></div>");
                $(companionBlock).append(companionMessage);
                $("#chat").append(companionBlock);
            } else if (userName == $("#current").val()) {
                var userMessage = $(`<video width="320" height="240" class="my-file-message" controls>
  <source src="/messageVideos/${file}">
</video>`);

                var userBlock = $("<div class='messages my-message'></div>");
                $(userBlock).append(userMessage);
                $("#chat").append(userBlock);
            }

            document.querySelector("#chat").scrollTop = document.querySelector("#chat").scrollHeight;
            return;
        }
    });

hubConnection.on('ChangeUserRelationship',
    function () {
        let elem = $("#relationshipButton");
        if ($(elem).hasClass('btn-success')) {
            $(elem).toggleClass('btn-danger btn-success');
            $("#message").prop("disabled", false);
            $("#message").attr("placeholder", "Type a message");
            $("#attachment-container").css("display", "flex");
            $(elem).text('Unblock');
        } else {
            $(elem).toggleClass('btn-success btn-danger');
            $("#message").prop("disabled", true);
            $("#message").attr("placeholder", "You can't write this user");
            $("#attachment-container").css("display", "none");
            $(elem).text('Block');
        }
    });

hubConnection.on('ChangeOnline',
    function (status) {
        $("#user-status").text(status);
    });

hubConnection.start();