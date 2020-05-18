<template>
    <div id="cart">
        <form action="" method="post">
            <input type="text" name="test1" v-model="storetestname" value="" />
            <button @click.prevent="postTest">Submit</button>
        </form>
        <p>{{ storetestname }}</p>
        <form action="" method="post">
            <input type="text" name="test1" v-model="testtest" value="" />
        </form>
        <p>{{ testtest }}</p>
    </div>
</template>

<script>

export default {  
  data() {
    return {
        //testname:""    
    }
  },
  methods: {
        addtestname() {
          this.$store.state.testname = this.testname;
      },
      postTest() { 
          this.$store.dispatch('postTest');
      }
  },
  computed: {
      storetestname: {
          get() {
              return this.$store.state.testname.testname;
          },
          set(value) {               
              this.$store.commit('updateName', value)
          }          
      },
      testtest: {
          get() {
              return this.$store.state.carts;
          },
          set(value) {
              this.$store.commit('updateCarts', value)
          }          
      }
      
  },

       
}
</script>

<style>

</style>
