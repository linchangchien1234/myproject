//載入框架
import Vue from 'vue'

//Vuex方法載入
import Vuex from 'vuex'
Vue.use(Vuex);
Vue.config.devtools = true

//ajax axios方法載入
import Vueaxios from 'vue-axios'
import axios from 'axios'
Vue.use(Vueaxios, axios)



const userRequest = axios.create({
    baseURL: 'https://localhost:44377',
    headers: { 'Content-Type': 'application/json' },
});
export const store = new Vuex.Store({
    state: {
        //測試用
        tests: [
            { name: 'AA', price: 20 },
            { name: 'BB', price: 30 },
            { name: 'CC', price: 40 },
            { name: 'DD', price: 50 }
        ],
        //測試用
        testid: 0,
        //測試用
        testname: {
            testname: "AAAA"
        },
        //測試用
        testtest: "aaaa",
        //cart資料
        carts: [],
        //articles資料
        articles: [],
        //Article轉址ID
        //ArticlesId:null,
        articleid: 1,
        personid:1,
        persons: [],
        personsform: {},
        messagesToarticle: {
            articleid: null,
            messageid: null
        },
        messages: {
            body: "",
            userid: null
        }
    },
    getters: {
        //測試用
        addTest: state => {
            var addTest = state.tests.map(test => {
                return {
                    name: '**' + test.name + '**',
                    price: test.price / 2
                }
            });
            return addTest;
        },
        //測試用
        addId: state => {
            return state.testid; 
        },
        //測試用
        testname: state => {
            return state.testname;
        },
        //測試用
        addArticleId: state => {
            return state.articleid; 
        },
        addPersonid: state => {
            return state.personid;
        },
        messages: state => {
            return state.messages;
        },
        messagesToarticle: state => {
            return state.messagesToarticle;
        },
        persons:state => {
            return state.persons;
        },
        personsform: state => {
            return state.personsform;
        }
    },
    mutations: {
        //測試用
        reduceTest: state => {
            state.tests.forEach(test => {
                test.price -= 1;
            });
        },
        //測試用
        updateTest: (state, value) => {
            state.testtest = value;
        },
        updateName: (state, value) => {
            state.testname.testname = value;            
        },
        //Article轉址ID
        /*
        updateArticlesId: (state, value) => {
            state.ArticlesId = value;
        },*/
        updateMessage: (state, value) => {
            state.messages = value; 
        },
        updatePerson: (state, value) => {
            state.persons = value; 
        }
    },
    actions: {
        //測試用
        reduceTest: state => { 
            setTimeout(function () {
                state.commit('reduceTest');
            }, 2000)
        },
        //api管理
        getCartapi() {
            return userRequest.get('/api/cartapi/');
        },
        postCartapi(data) {
            return userRequest.post('/api/cartapi/', data);
        },
        getArticleapi() {
            return userRequest.get('/api/articleapi/');
        },
        postArticleapi(data) {
            return userRequest.post('/api/articleapi/', data);
        },
        getArticleapiId:state => {
            var id = state.getters.addArticleId;
            console.log(id);
            return userRequest.get('/api/articleapi/' + id);
        },
        postArticleapiId: state => {
            var id = state.getters.addArticleId;
            console.log(id);
            return userRequest.post('/api/articleapi/'+ id,data);
        },
        getPersonapi() {
            return userRequest.get('/api/personapi/'); 
        },
        getPersonapiId:state => {
            var id = state.getters.addPersonid;
            console.log(id);
            return userRequest.get('/api/personapi/' + id);
        },
        postPersonapi(data) {
            console.log(data);
            return userRequest.post('/api/personapi/', data.getters.persons);
        },
        putPersonapi(state){
            var id = state.getters.addPersonid;
            console.log(id);
            console.log(state);
            console.table(state.getters.persons);
            var data = Object.assign({}, state.getters.persons[0]);
            console.table(data);            
            //var data = JSON.stringify(state.getters.persons);
            //console.log(data);
            return userRequest.put('/api/personapi/' + id, data);
        },
        getMessageapi() {
            return userRequest.get('/api/messageapi/');
        },
        postMessageapi(data) {
            console.log(data);
            return userRequest.post('/api/messageapi/', data.getters.messages);
        },
        getMessagesToarticle() {
            return userRequest.get('/api/messagesToarticle/');
        },
        postMessagesToarticle(data) {
            return userRequest.post('/api/messagesToarticle/', data.getters.messagesToarticle);
        },
        postTest(data) {           
            userRequest.post('/api/test/', data.getters.testname)
                .then((result) => {
                    console.log(result);
                })
                .catch((err) => { console.error(err) });
        }
    },
})