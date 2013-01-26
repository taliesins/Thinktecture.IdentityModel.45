var stsEndpoint = 'https://ip.talifun.com/issue/oauth2',
    scope = 'https://api.talifun.com/',
    serviceEndpoint = 'https://adfs.leastprivilege.vm/webapisecurity/api/identity',
    authN,
    token;

$(function () {
    authN = new thinktectureIdentityModel.BrokeredAuthentication(stsEndpoint, scope);
});

function login() {
    $('#idpToken').val('');
    $('#claims').empty();

    var un = $('#username').val(),
        pw = $('#password').val();

    authN.requestIdpToken(un, pw, idpTokenAvailable);
};

function idpTokenAvailable(idpToken) {
    $('#idpToken').val(idpToken);
    token = idpToken;
};

function getIdentity() {
    $('#claims').empty();
    getIdentityClaimsFromService();
};

function getIdentityClaimsFromService() {
    var authHeader = authN.createAuthenticationHeader(token);

    $.ajax({
        type: 'GET',
        cache: false,
        url: serviceEndpoint,
        beforeSend: function (req) {
            req.setRequestHeader('Authorization', authHeader);
        },
        success: function (result) {
            $.each(result.Claims, function () {
                $('#claims').append($('<li>').text(this.ClaimType + ':  ' + this.Value));
            });
        },
        error: function (error) {
            alert('Error: ' + error.responseText);
        }
    });
}