fetch("http://localhost:5000/api/user/getusers")
.then(response => response.json())
.then((result) => {
    console.log(result)

});