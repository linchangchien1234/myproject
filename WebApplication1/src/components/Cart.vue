<template>
    <div id="cart">
        <div class="card" v-for="(item, index) in carts">
            <div class="card-body">
                <h3>{{ index }}</h3>
                <h5 v-bind:class="'item'+item.id+' card-title'">{{ item.name }}</h5>
                <p class="card-text">{{ item.namedetail }}</p>
                <p v-bind:class="'item'+item.id+' card-text'">{{ item.price }}</p>
                <button v-bind:id="item.id" class="test btn btn-primary" @click.prevent="addcart">Go somewhere</button>
            </div>
        </div>
        <div v-for="(item, name) in addTests">
            <h1>{{ item.name }}</h1>
            <p>{{ item.price }}</p>
        </div>
        <button class="test btn btn-primary" @click.prevent="reduceTest">Submit</button>
    </div>
</template>

<script>

export default {
  data () {
    return {
        //carts: [],
        //testPush: {}
    }
  },
  methods: {
      addcart(event) {
          var id = event.target.id;
          console.log(id);
          var nameValue = document.getElementsByClassName("item" + id)[0].innerText;
          var priceValue = document.getElementsByClassName("item" + id)[1].innerText;
          this.$store.state.tests.push({ name: nameValue, price: priceValue });                   
      },
      reduceTest() {
          this.$store.dispatch('reduceTest');
      },
      getUsers() {
          this.$store.dispatch('getUsers');
      }

        },
        created() {  
            this.$store.dispatch('getCartapi')
                .then((result) => {
                    this.$store.state.carts = result.data;
                    //console.table(result.data);
                })
                .catch((err) => { console.error(err) })
        },
        computed: {
            tests() {
                return this.$store.state.tests;
            },
            addTests() {
                return this.$store.getters.addTest;
            },
            carts() {
                return this.$store.state.carts;
            }
        }
       
}
</script>

<style>
    
</style>
