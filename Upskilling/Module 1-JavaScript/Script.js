const courses = [
    { name: "C# Programming", credits: 4 },
    { name: "Angular", credits: 4 },
    { name: "SQL", credits: 3 }
];

function welcomeStudent() {
    const name = document.getElementById("studentName").value.trim();

    if (name === "") {
        document.getElementById("message").textContent =
            "Please enter your name.";
        return;
    }

    document.getElementById("message").textContent =
        `Welcome, ${name}!`;
}

function showCourses() {
    const list = document.getElementById("courseList");

    list.innerHTML = "";

    courses.forEach(course => {
        const item = document.createElement("li");
        item.textContent =
            `${course.name} - ${course.credits} Credits`;
        list.appendChild(item);
    });
}