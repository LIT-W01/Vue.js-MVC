new Vue({
    el: '.people-div',
    data: {
        people: [],
        person: {},
        editMode: false,
        sortLastNameAsc: false
    },
    ready: function() {
        this.populatePeople();
    },
    methods: {
        populatePeople: function() {
            var self = this;
            $.getJSON('/home/getpeople', function(people) {
                self.people = people;
            });
        },
        addPerson: function () {
            this.editMode = false;
            $(".modal").modal();
        },
        addPersonSave: function () {
            var self = this;
            $.post("/home/addperson", this.person, function(p) {
                self.people.push(p);
                $(".modal").modal('hide');
                self.person = {};
            });
        },
        deletePerson: function (personId) {
            var self = this;
            $.post("/home/deleteperson", { id: personId }, function () {
                self.populatePeople();
            });
        },
        editPerson: function (person) {
            this.editMode = true;
            this.person = {
                FirstName: person.FirstName,
                LastName: person.LastName,
                Age: person.Age,
                Id: person.Id
            };
            $(".modal").modal();
        },
        editPersonSave: function() {
            var self = this;
            $.post("/home/updateperson", this.person, function() {
                $(".modal").modal('hide');
                self.populatePeople();
            });
        },
        sortPeople: function() {
            this.sortLastNameAsc = !this.sortLastNameAsc;
            var self = this;
            this.people.sort(function(a, b) {
                if (!self.sortLastNameAsc) {
                    var temp = a;
                    a = b;
                    b = temp;
                }

                return a.LastName < b.LastName ? -1 : 1;
            });
        }
    }
});

