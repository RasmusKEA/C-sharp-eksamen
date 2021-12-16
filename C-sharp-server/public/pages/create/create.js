document.getElementById("create-button").addEventListener("click", createProject)

function createProject(){
    if(document.getElementById("tourname").value !== '' && document.getElementById("description").value !== '' && document.getElementById("milestones").value !== '' && document.getElementById("distance").value !== '' && document.getElementById("time").value !== '' && document.getElementById("image").value !== ''){
        fetch(`http://localhost:5000/api/tour/createtour`, {
            method: "POST",
            headers: { "Content-type": "application/json; charset=UTF-8" },
            body: JSON.stringify({
                name: document.getElementById("tourname").value,
                description: document.getElementById("description").value,
                milestones: document.getElementById("milestones").value,
                distance: document.getElementById("distance").value,
                time: document.getElementById("time").value,
                image: document.getElementById("image").value
            })  
        }).then(response => {
            if (response.status === 200) {
                console.log("Everything went well");
                window.location.href = '/admin'
            } else {
                console.log("Update succesful", response.status);
            }
        });
    }else{
        window.alert("You need to fill out all fields before applying changes.")
    }
}