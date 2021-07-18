var connection = new signalR.HubConnectionBuilder()
   // .withUrl('/Home/Index',
    .withUrl('https://localhost:44300/ChatHub',
        { accessTokenFactory: () => `eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEwMDQ0IiwibmFtZSI6ImRhbW15LmFkZWd1bndhQGdtYWlsLmNvbSIsImVtYWlsIjoiZGFtbXkuYWRlZ3Vud2FAZ21haWwuY29tIiwibmJmIjoxNjI2NTIzNTQyLCJleHAiOjE2MjY3MDM1NDIsImlzcyI6IkVraUhpcmUuQXBpIiwiYXVkIjoiRWtpSGlyZS5XZWIifQ.s-PUdXPY3pHPqXDjzMAsOK0OS2H-wweEjfXmT96TpMA` })
    .build();

connection.on('receiveMessage', addMessageToChat);

connection.start()
    .catch(error => {
        debugger;
        console.error(error);
        //console.error(error.message);
    });

function sendMessageToHub(message) {
    debugger;
    connection.invoke('SendMessage', message);
}