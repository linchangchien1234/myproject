<template>
    <div id="cart">
        <form>
            <div class="form-group">
                <label for="userName">User Name</label>
                <input type="text" class="form-control" id="userName" aria-describedby="nameHelp" v-model.lazy="persons.name">
            </div>
            <div class="form-group">
                <label for="userEmail">Email address</label>
                <input type="text" class="form-control" id="userEmail" aria-describedby="nameHelp" v-model.lazy="persons.email">
            </div>
            <div class="form-group">
                <label for="userAddress">Address</label>
                <input type="text" class="form-control" id="userAddress" aria-describedby="nameHelp" v-model.lazy="persons.address">
            </div>
            <div class="form-group">
                <label for="userAccount">Account</label>
                <input type="text" class="form-control" id="userAccount" aria-describedby="nameHelp" v-model.lazy="persons.account">
            </div>
            <div class="form-group">
                <label for="userPassword">Password</label>
                <input type="password" class="form-control" id="userPassword" v-model.lazy="persons.password">
            </div>
            <div class="form-group form-check">
                <p>What do you like?</p>
                <p>
                    <input type="checkbox" value="dog" id="exampleCheck1" v-model="persons.hobbys">
                    <label class="form-check-label" for="exampleCheck1">Dog</label>
                    <input type="checkbox" value="cat" id="exampleCheck2" v-model="persons.hobbys">
                    <label class="form-check-label" for="exampleCheck2">Cat</label>
                    <input type="checkbox" value="mouse" id="exampleCheck3" v-model="persons.hobbys">
                    <label class="form-check-label" for="exampleCheck3">Mouse</label>
                </p>
            </div>
            <div class="form-group">
                <label for="selectSex">Select your Sex</label>
                <select class="form-control" id="selectSex" v-model="persons.sex">
                    <option v-for="sex in sexs">{{ sex }}</option>
                </select>
            </div>
            <button type="submit" class="btn btn-primary" @click.prevent="submut">Submit</button>
        </form>

        <div>
            <h1>{{ persons.name }}</h1>
            <h3>{{ persons.email }}</h3>
            <p>{{ persons.address }}</p>
            <p>{{ persons.account }}</p>
            <p>{{ persons.password }}</p>
            <p v-for="hobby in persons.hobbys">{{ hobby }}</p>
            <p>{{ persons.sex }}</p>
        </div>
    </div>
</template>

<script>

export default {
  data () {
        return {
        persons: {
            name: '',
            email: '',
            address:'',
            account: '',
            password: '',
            hobbys: [],
            sex: ''
        },
        sexs: ['Boy', 'Girl'],
    }
  },
  methods: {
      submut() {
          this.$store.state.persons = this.persons;
          this.$store.dispatch('postPersonapi')
              .then((result) => {
                  console.log(this.persons);
                  console.log(result.data);
                  this.$store.dispatch('getPersonapi')
                      .then((result) => {    
                          var length = result.data.length -1;
                          console.log(result.data[length].id);
                          console.log(result.data.length);
                          document.location.href = "/person/detail/" + result.data[length].id;
                      })
                      .catch((err) => { console.error(err) })
              })
              .catch((err) => { console.error(err) })

          //firebase api          
          //const api = 'https://localhost:44377/api/personapi';

          /*
          $.ajax({
              url: api,
              type: post,
              data: this.persons, 
              success: function () {
                  console.log("success");
              }
          });*/ 
          /*
          this.$http.post(api, this.persons)
              .then((data) => {
                  //console.log(data);
                  this.$http.get(api)
                      .then((data) => {
                          console.log(data.data.length);
                          document.location.href = "/person/detail/" + data.data.length;
                      })
                      .catch(function (error) {
                          console.log(error);
                      });  
              })
              .catch(function (error) {
                  console.log(error);
              });         */
        }
        },  
        computed: {
           /*
            //抓取articles相關資料            
            persons: {
               get() {
                    return this.$store.state.persons;
               },
               set(value) {
                   //value的傳遞 正常
                   //想不通傳遞是什麼狀態
                   this.$store.commit('updatePerson', value)
               }
           }*/
        },
        created() {

        }
       
}
</script>

<style>

</style>
