;var hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/chat")
    .build();


hubConnection.serverTimeoutMilliseconds = 1000 * 60 * 10;

hubConnection.on('Receive',
    function(message, userName) {

        let lastElemInChat = $(".messages").last();
        if (userName == $("#friend").val()) {
            var companionMessage = $("<div class='companion-message'></div>");
            $(companionMessage).text(message);
            companionMessage = $("<div></div>").append(companionMessage);

            if (!lastElemInChat.hasClass("my-message")) {
                $(lastElemInChat).append(companionMessage);
            } else {
                var companionBlock = $("<div class='messages'></div>");
                $(companionBlock).append(companionMessage);
                $("#chat").append(companionBlock);
            }
        } else if (userName == $("#current").val()) {
            var userMessage = $("<div class='my-message-text'></div>");
            $(userMessage).text(message);
            userMessage = $("<div></div>").append(userMessage);

            if (lastElemInChat.hasClass("my-message")) {
                $(lastElemInChat).append(userMessage);
            } else {
                var userBlock = $("<div class='messages my-message'></div>");
                $(userBlock).append(userMessage);
                $("#chat").append(userBlock);
            }
        }

        document.querySelector("#chat").scrollTop = document.querySelector("#chat").scrollHeight;
    });

hubConnection.start();