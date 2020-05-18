<template>
    <div id="person" class="container">
        <div class="d-flex justify-content-center align-items-center size">
            <div class="text-center w-50">
                <form action="/" method="post">
                    <h3>Person Registered</h3>
                    <div>
                        <input type="text" name="username" v-model="username" value="" />
                    </div>
                    <div>
                        <input type="password" name="userpassword" v-model="userpassword" value="" />
                    </div>
                    <p>{{ message }}</p>
                    <button class="btn btn-outline-success my-2 my-sm-0" @click.prevent="ckeckUser">Send</button>
                </form>
                <p>{{ this.id }}</p>
            </div>            
        </div>
    </div>
</template>

<script>

    export default {
        data() {
            return {
                //persons: [],
                username: "",
                userpassword: "",
                message: "",
                id:null
            }
        },
        methods: {
            ckeckUser() {
                for (var i = 0; i <= this.$store.state.persons.length; i++) {
                    if ((this.username === this.$store.state.persons[i].account) && (this.userpassword == this.$store.state.persons[i].password)) {
                        this.message = "good job!";
                        this.id = this.$store.state.persons[i].id;
                        document.location.href = "/person/detail/"+this.id;
                        break;
                    } else {
                        this.message = "bad!~~~~";
                    }
                } 
                /*
                for (var i = 0; i < this.persons.length; i++) {
                    this.message = this.persons[i].account;                    
                } */
            }
        },
        computed: {

        },
        created() {
            this.$store.dispatch('getPersonapi')
                .then((result) => {
                    this.$store.state.persons = result.data;
                    this.personsLength = this.$store.state.persons.length;
                    console.table(result.data);
                })
                .catch((err) => { console.error(err) })
            /*
            const api = 'https://localhost:44377/api/personapi/';

            this.$http.get(api)
                .then((data) => {                    
                    this.persons = data.data;  
                    console.log(data.data);
                    console.log(this.persons);
                    //console.log(this.persons[0].adress);
                })
                .catch(function (error) {
                    console.log(error);
                });*/
        }

    }
</script>

<style>
    .size {
        height: 500px;
    }
</style>

