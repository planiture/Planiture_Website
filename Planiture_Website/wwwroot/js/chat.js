document.addEventListener('DOMContentLoaded', function () {
    document.body.appendChild('<div id="chat-box-header" style="display: block;position:' + options.position + ';' + getPlacement() + 'width:' + options.width + 'px;padding:' + options.headerPaddings + ';color:' + options.headerTextColor + ';font-size:' + options.headerFontSize + ';cursor:pointer;background:' + options.headerBackgroundColor + ';filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=\'' + options.headerGradientStart + '\', endColorstr=\'' + options.headerGradientEnd + '\');background: -webkit-gradient(linear, left top, left bottom, from(' + options.headerGradientStart + '), to(' + options.headerGradientEnd + '));background: -moz-linear-gradient(top,  ' + options.headerGradientStart + ',  ' + options.headerGradientEnd + ');border:1px solid ' + options.headerBorderColor + ';box-shadow:inset 0 0 7px #0354cb;-webkit-box-shadow:inset 0 0 7px #0354cb;border-top-left-radius: 5px;border-top-right-radius: 5px;">' + options.offlineTitle + '</div>' +
        '<div id="chat-box" style="display:none;position:' + options.position + ';' + getPlacement() + 'width:' + options.width + 'px;height:300px;padding: 10px 10px 10px 10px;border: 1px solid ' + options.boxBorderColor + ';background-color:' + options.boxBackgroundColor + ';opacity: 0.8;font-size:14px !important;color: black !important;"></div>'
    );

    var chatKey = 'lcsk-chatId';
    var requestChat = false;
    var chatId = '';
    var chatEditing = false;

    //start the connection
    var connection = new signalR.HubConnectionBuilder()
        .withUrl('/chatHub')
        .build();

    function setDefaults() {
        options.position = 'fixed';
        options.placement = 'bottom-right';

        options.headerPaddings = '3px 10px 3px 10px';
        options.headerBackgroundColor = '#0376ee';
        options.headerTextColor = 'white';
        options.headerBorderColor = '#0354cb';
        options.headerGradientStart = '#058bf5';
        options.headerGradientEnd = '#015ee6';
        options.headerFontSize = '15px';

        options.boxBorderColor = '#0376ee';
        options.boxBackgroundColor = '#fff';

        options.width = 250;

        options.offlineTitle = 'Contact us!';
        options.onlineTitle = 'Chat with us!';

        options.waitingForOperator = 'Thanks, give us 1 minute to accept the chat...';
        options.emailSent = 'Your email was sent, thanks we\'ll get back to you asap.';
        options.emailFailed = 'Doh! The email could not be sent at the moment.<br /><br />Sorry about that.';

    }

    document.body.on.addEventListener("keydown", function () {

    });

    connection.on("onlineStatus", function () {
        chatRefreshState(state);
    });

    function chatRefreshState(state) {
        if (state) {
            document.getElementById("chat-box").innerText(options.onlineTitle);
            if (!requestChat) {
                document.getElementById("chat-box").innerHTML('<div id="chat-box-msg" style="height:265px;overflow:auto;">' +
                    '<p>Have a question? Let\'s chat!</p><p>Add your question on the field below and press ENTER.</p></div>' +
                    '<div id="chat-box-input" style="height:35px;"><textarea id="chat-box-textinput" style="width:100%;height: 32px;border:1px solid #0354cb;border-radius: 3px;" /></div>'
                );
            }
            else
                if (!chatEditing) {
                    document.getElementById("chat-box-header").innerText(options.onlineTitle);
                    document.getElementById("chat-box-input").style.display = "none";
                    document.getElementById("chat-box").innerHTML('<p>Your email</p><input type="text" id="chat-box-email" style="border:1px solid #0354cb;border-radius: 3px;width: 100%;" class="chat-editing" />' +
                        '<p>Your message</p><textarea id="chat-box-cmt" cols="40" rows="7" class="chat-editing" style="border:1px solid #0354cb;border-radius: 3px;"></textarea>' +
                        '<p><input type="button" id="chat-box-send" value="Contact us" />'
                );

                }
        }

    }
});