const nameInput = document.querySelector("#nameInput");
const salaryInput = document.querySelector("#salaryInput");
const saveBtn = document.querySelector("#saveButton");
const container = document.querySelector(".container");
const containerDiv = document.querySelector(".container div");
const deleteBtn = document.querySelector(".deleteButton");

function clearForm() {
  nameInput.value = "";
  salaryInput.value = "";
  deleteBtn.classList.add("hidden");
}
function addEmployee(empname, empsalary) {
  const body = {
    EmployeeName: empname,
    salary: empsalary,
  };
  console.log(body);
  fetch("https://localhost:7153/api/employees", {
    method: "POST",
    body: JSON.stringify(body),
    headers: {
      "Content-Type": "application/json",
    },
  })
    .then((data) => data.json())
    .then((res) => {
      clearForm();
      getEmployees();
    })
    .catch((err) => console.log(err));
}
function displayEmployees(employees) {
  employees.forEach((employee) => {
    var div = document.createElement("div");
    div.innerHTML = `<h4>${employee.employeeId}</h4>
                        <p>${employee.employeeName}</p>
                        <p>${employee.salary}</p>
                       `;
    container.appendChild(div);
    div.addEventListener("click", function () {
      getEmployeesById(employee.employeeId);
    });
  });
}
function populateForm(emp) {
  nameInput.value = emp.employeeName;
  salaryInput.value = emp.salary;
  deleteBtn.classList.remove("hidden");
  deleteBtn.setAttribute("data-id", emp.employeeId);
  saveBtn.setAttribute("data-id", emp.employeeId);
}

function getEmployeesById(id) {
  fetch(`https://localhost:7153/api/employees/${id}`)
    .then((data) => data.json())
    .then((res) => populateForm(res));
}

function getEmployees() {
  fetch("https://localhost:7153/api/employees")
    .then((data) => data.json())
    .then((res) => displayEmployees(res));
}
function updateEmployee(id, empname, empsalary) {
    const body = {
    EmployeeId:id,
    EmployeeName: empname,
    salary: empsalary,
  };
  console.log(body);
  fetch(`https://localhost:7153/api/employees/${id}`, {
    method: 'PUT',
    body: JSON.stringify(body),
    headers: {
      "Content-Type": "application/json",
    },
  })
    .then((res) => {
      clearForm();
      getEmployees();
    });
}
function deleteEmployee(id) {
  fetch(`https://localhost:7153/api/employees/${id}`, {
    method: "DELETE",
  }).then((res) => {
    clearForm();
    getEmployees();
  });
}

deleteBtn.addEventListener("click", function () {
  const id = deleteBtn.dataset.id;
  deleteEmployee(id);
});

getEmployees();
saveBtn.addEventListener("click", function () {
  const id = saveBtn.dataset.id;
  if (id) {
    updateEmployee(id, nameInput.value, salaryInput.value);
  } else {
    addEmployee(nameInput.value, salaryInput.value);
  }
});
