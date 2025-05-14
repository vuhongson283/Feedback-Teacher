document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("loginForm").addEventListener("submit", function (event) {
        var emailInput = document.getElementById("email").value.trim();
        var passwordInput = document.getElementById("password").value.trim();

        var emailPattern = /^[a-zA-Z0-9._%+-]+@(fpt\.edu\.vn|fe\.edu\.vn)$/;

        if (!emailPattern.test(emailInput)) {
            alert("Email phải có dạng example@fpt.edu.vn hoặc example@fe.edu.vn");
            event.preventDefault();
            return;
        }

        if (passwordInput.length < 5) {
            alert("Mật khẩu phải có ít nhất 5 ký tự!");
            event.preventDefault();
            return;
        }
    });
});
