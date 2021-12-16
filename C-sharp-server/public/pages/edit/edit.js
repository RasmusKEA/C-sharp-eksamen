let editID = localStorage.getItem("editID")

fetch(`http://localhost:5000/api/tour/gettour/${editID}`)
.then(response => response.json())
.then((result) => {
    document.getElementById("tourname").value = result[0].name
    document.getElementById("description").value = result[0].description
    document.getElementById("milestones").value = result[0].milestones
    document.getElementById("distance").value = result[0].distance
    document.getElementById("time").value = result[0].time
    document.getElementById("image").value = result[0].image
});

document.getElementById("update-button").addEventListener("click", updateTour)

function updateTour
(){
    if(document.getElementById("tourname").value !== '' && document.getElementById("description").value !== '' && document.getElementById("milestones").value !== '' && document.getElementById("distance").value !== '' && document.getElementById("time").value !== '' && document.getElementById("image").value !== ''){
        fetch(`http://localhost:5000/api/tour/puttour`, {
            method: "PUT",
            headers: { "Content-type": "application/json; charset=UTF-8" },
            body: JSON.stringify({
                idroutes : editID,
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