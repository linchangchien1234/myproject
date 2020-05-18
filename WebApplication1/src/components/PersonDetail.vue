<template>
    <div id="cart">
        <table class="table">
            <tr>
                <th scope="col">#</th>
                <th scope="col">Name</th>
                <th scope="col">Adress</th>
                <th scope="col">Email</th>
                <th scope="col">Account</th>
                <th scope="col">Password</th>
                <th scope="col">Hobby</th>
            </tr>
            <tr v-for="(item, name) in persons">
                <th scope="row">{{ name + 1 }}</th>
                <td scope="row"><input type="text" name="name" v-model:value=" item.name" disabled /></td>
                <td scope="row"><input type="text" name="name" v-model:value=" item.adress" disabled /></td>
                <td scope="row"><input type="text" name="name" v-model:value=" item.email" disabled /></td>
                <td scope="row"><input type="text" name="name" v-model:value=" item.account" disabled /></td>
                <td scope="row"><input type="text" name="name" v-model:value=" item.password" disabled /></td>
                <td scope="row"><input type="text" name="name" v-model:value=" item.hobby" disabled /></td>
            </tr>
        </table>
        <a class="btn btn-outline-success my-2 my-sm-0" id="toggle" @click="changeDisabled(false)" v-if="this.staute === 1">Edit</a>
        <a class="btn btn-outline-success my-2 my-sm-0" id="toggle" @click="changeDisabled2(true)" v-else>Save</a>
        <a class="btn btn-outline-success my-2 my-sm-0" href="/person">Back</a>
    </div>
</template>

<script>

export default {
  data () {
    return {
        id: null,
        hrefUrl: "",
        //persons: {},
        staute:1
    }
  },
        methods: {  
            test(value) {
                var changeDisabled = document.getElementsByTagName("input");
                var changeDisabledIndex = changeDisabled.length;
                for (var i = 0; i <= changeDisabledIndex; i++) {
                    //方法一
                    /*  disabled有報錯誤
                     *  vue.esm.js?a4b5:1897 TypeError: Cannot set property 'disabled' of undefined
                     *  功能正常
                     */
                    changeDisabled[i].disabled = value;                   
                    //方法二
                    /*  removeAttribute有報錯誤
                     *  getAttribute有報錯誤
                     *  vue.esm.js?a4b5:1897 TypeError: Cannot set property 'removeAttribute' of undefined
                     *  vue.esm.js?a4b5:1897 TypeError: Cannot set property 'getAttribute' of undefined
                     *  功能正常
                     */
                    /*
                    if (value === false) {
                        changeDisabled[i].removeAttribute("disabled");
                    } else {
                        changeDisabled[i].getAttribute("disabled");
                        changeDisabled[i].setAttribute("disabled", value)
                    }
                    */
                }
            },
            changeDisabled(value) {
                this.staute = 2;    
                this.test(value);
            },
            changeDisabled2(value) {
                this.staute = 1;
                
                this.$store.dispatch('putPersonapi')
                    .then((result) => {
                        console.table(result.data);
                    })
                    .catch((err) => { console.error(err) })
                  /*
                const api = 'https://localhost:44377/api/personapi/'+this.id;
                var data = Object.assign({}, this.persons[0]);
                console.log(data);
                this.$http.put(api, this.persons[0])
                    .then((data) => {
                        console.log(data);
                    })
                    .catch(function (error) {
                        console.log(error);
                    });*/
                this.test(value);
            }
        },
        computed: {
            //抓取articles相關資料
            
            persons() {
                return this.$store.state.persons;
            }
        },
        created() {
            this.hrefUrl = location.href;  
            
            this.$store.state.personid = this.hrefUrl.substring(38, this.hrefUrl.length);
            this.$store.dispatch('getPersonapiId')
                .then((result) => {
                    console.table(result.data);
                    this.$store.state.persons = result.data;
                    this.personsLength = this.$store.state.persons.length;
                    console.table(this.$store.state.persons);
                    //console.table(result.data);
                })
                .catch((err) => { console.error(err) })
               
            /*
            this.id = this.hrefUrl.substring(38, this.hrefUrl.length);
            const api = 'https://localhost:44377/api/personapi/' + this.id;

            this.$http.get(api)
                .then((data) => {
                    this.persons = data.data;
                    console.log(data.data);                    
                    //console.log(this.persons[0].adress);
                })
                .catch(function (error) {
                    console.log(error);
                }); */
        }
       
}
</script>

<style>

</style>
