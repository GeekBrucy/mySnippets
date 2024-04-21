let submitBtn = document.getElementById("submit-btn");

const baseUrl = "http://localhost:5194"

submitBtn.addEventListener("click", (e) => {
  e.preventDefault();
  const userName = document.getElementById("username-input").value;
  const password = document.getElementById("password-input").value;

  axios.post(`${baseUrl}/api/Login`, {
    userName,
    password
  })
  .then(function (response) {
    if (response.data.ok) {
      alert("Login successfully");
    } else {
      alert("Login failed");
    }
  })
  .catch(function (error) {
    console.log(error);
  });
});