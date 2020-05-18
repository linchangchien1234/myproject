<template>
    <div id="articleDetailId">
        <div v-for="(item, name) in articles">
            <div v-if="name == 0">
                <h3>Article</h3>
                <h2>{{ item.n.header}}</h2>
                <p>{{ item.n.body}}</p>
                <h3>{{ item.m.name}}</h3>
            </div>
            <div>
                <h3 v-if="name == 0">Message</h3>
                <p>{{ item.p.body}}</p>
                <h3>{{ item.q.name}}</h3>
            </div>
        </div>
        <input type="text" name="message" v-model="messages.body" value="" />
        <input type="text" name="username" v-model="username" value="" />
        <button @click="messageAdd">Submit</button>
        <p>{{ messages.body }}</p>
        <p>{{ username }}</p>
        <p>{{ tests }}</p>
    </div>
</template>

<script>

    export default {
        data() {
            return {
                id: 1,
                //articles: [],
                //persons: [],
                personsLength:null,
                username: "", 
                /*
                messagesToarticle: {
                    articleid: null,
                    messageid: null
                },
                messages: {
                    body: "",
                    userid:null
                },*/
                //articleid:1
            }
        },
        methods: {
            messageAdd() {                
                //console.log(this.persons);
                this.$store.state.messagesToarticle.articleid = this.id;
                for (var i = 0; i <= this.personsLength; i++) {
                    if (this.$store.state.persons[i].name == this.username) {
                        //console.log(this.$store.state.persons[i].id);
                        this.$store.state.messages.userid = this.$store.state.persons[i].id;
                        //console.log(this.$store.state.messages.userid);
                        break;
                    }
                }
                //console.log(this.messages);

                //結合Vuex action ajax
                
                this.$store.dispatch('postMessageapi')
                    .then((result) => {
                        this.$store.dispatch('getMessageapi')
                            .then((result) => {
                                var length = result.data.length;
                                //console.table(length);
                                //console.table(result.data);
                                var total = result.data[length - 1].id;
                                this.$store.state.messagesToarticle.messageid = total;
                                //console.table(total);
                                //console.table(this.$store.state.messagesToarticle.messageid);
                                this.$store.dispatch('postMessagesToarticle')
                                    .then((result) => {
                                        //console.log(this.messagesToarticle);
                                        document.location.href = "/article/detail/" + this.id;
                                        //console.table(result.data);
                                    })
                                    .catch((err) => { console.error(err) });
                            })
                            .catch((err) => { console.error(err) });
                        //console.table(result.data);                                                
                    })
                    .catch((err) => { console.error(err) });
                
                
                

                /*
                const api = 'https://localhost:44377/api/messageapi/';
                this.$http.post(api, this.messages)
                    .then((data) => {
                        this.$http.get(api)
                            .then((data) => {
                                var length = data.data.length;
                                this.messagesToarticle.messageid = data.data[length - 1].id;
                                const api2 = 'https://localhost:44377/api/messagesToarticle/';
                                this.$http.post(api2, this.messagesToarticle)
                                    .then((data) => {
                                        console.log("456");
                                        console.log(this.messagesToarticle);
                                        document.location.href = "/article/detail/" + this.id;
                                        console.log(data);
                                    })
                                    .catch(function (error) {
                                        console.log(error);
                                    });
                            })
                            .catch(function (error) {
                                console.log(error);
                            });
                    })
                    .catch(function (error) {
                        console.log(error);
                    });*/
            }
        },
        computed: {
            //抓取articles相關資料
            articles() {
                return this.$store.state.articles;
            },
            messages: {
                get() {
                    return this.$store.state.messages;
                },
                set(value) {
                    //value的傳遞 正常
                    //想不通傳遞是什麼狀態
                    this.$store.commit('updateMessage', value)
                }
            }

        },
        created() {
            this.hrefUrl = location.href;
            this.id = this.hrefUrl.substring(39, this.hrefUrl.length);            
            this.$store.state.articleid = this.id;
            //結合Vuex action ajax
            this.$store.dispatch('getArticleapiId')
                .then((result) => {
                    this.$store.state.articles = result.data;
                    //console.table(result.data);
                })
                .catch((err) => { console.error(err) });                
            this.$store.dispatch('getPersonapi')
                .then((result) => {
                    this.$store.state.persons = result.data;
                    this.personsLength = this.$store.state.persons.length;
                    //console.table(result.data);
                })
                .catch((err) => { console.error(err) })

            /*vue axios
             * const api = 'https://localhost:44377/api/articleapi/' + this.id;
             * this.$http.get(api)
                .then((data) => {
                    this.articles = data.data;
                    //console.log(data.data);
                })
                .catch(function (error) {
                    console.log(error);
                });
            const apiUser = 'https://localhost:44377/api/personapi/'
            this.$http.get(apiUser)
                .then((data) => {
                    this.persons = data.data;
                    this.personsLength = this.persons.length;
                })
                .catch(function (error) {
                    console.log(error);
                });*/
        }
    }
</script>

<style>
</style>
<!--

-->
