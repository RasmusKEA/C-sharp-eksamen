fetch("http://localhost:5000/api/tour/gettours")
.then(response => response.json())
.then((result) => {
    const tourWrapperDiv = document.getElementById("tour-container wrap");
    console.log(result)

    result.map(result => { 
        const tourDiv = document.createElement("div");
        
        tourDiv.className = "tour-div"
        tourDiv.innerHTML = `
            <h4>${result.name}</h4>
            <p>Beskrivelse: ${result.description}</p>
            <p>Milepæle: ${result.milestones}</p>
            <p>Afstand: ${result.distance} km</p>
            <p>Tid: ${result.time}</p>
        `;

        const editButton = document.createElement("button")
        editButton.className = "btn btn-primary shadow-none dl-cv edit-button"
        editButton.id = result.idroutes
        editButton.innerHTML = "Rediger"

        const deleteButton = document.createElement("button")
        deleteButton.className = "btn btn-primary shadow-none dl-cv delete-button"
        deleteButton.id = result.idroutes
        deleteButton.innerHTML = "Slet"

        tourDiv.append(editButton)
        tourDiv.append(deleteButton)
        tourWrapperDiv.appendChild(tourDiv);

        editButton.onclick = function (){
            location.href = '/edit'
            localStorage.setItem("editID", result.idroutes)
        }

        deleteButton.onclick = function(){
            fetch(`http://localhost:5000/api/tour/deletetour/${result.idroutes}`, {
                method: "DELETE"
            }).then(response => {
                if (response.status === 202) {
                    console.log("Everything went well");
                    window.location.href = '/admin'
                } else {
                    console.log("Delete succesful", response.status);
                }
            });
        }
    });
});

document.getElementById("create-button").addEventListener("click", createTour)

function createTour(){
    location.href = '/create'
}