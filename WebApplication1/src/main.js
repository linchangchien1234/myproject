//載入框架
import Vue from 'vue'
import '../node_modules/bootstrap/dist/css/bootstrap.css'
import '../node_modules/bootstrap/dist/js/bootstrap.js'
import '../node_modules/jquery/dist/jquery.js'
/*------------------------------------------------------*/
//components
import App from './App.vue'
//公用component
import AppHeader from './components/Header.vue'
import AppFooter from './components/Footer.vue'
//cart component
import Cart from './components/Cart.vue'
import CartDetail from './components/CartDetail.vue'
import CartFrom from './components/CartFrom.vue'
//person component
import Person from './components/Person.vue'
import PersonDetail from './components/PersonDetail.vue'
import PersonFrom from './components/PersonFrom.vue'
//article component
import Article from './components/Article.vue'
import ArticleDetail from './components/ArticleDetail.vue'
import ArticleFrom from './components/ArticleFrom.vue'
/*------------------------------------------------------*/
//ajax axios方法載入
import Vueaxios from 'vue-axios'
import axios from 'axios'
Vue.use(Vueaxios, axios)

//vuex
import { store } from './store/store'


new Vue({
    el: '#app',
    store:store,
    components: {
        'app': App,
        "app-header": AppHeader,
        "app-footer": AppFooter,
        "app-cart": Cart,
        "app-cartdetail": CartDetail,
        "app-cartfrom": CartFrom,
        "app-person": Person,
        "app-persondetail": PersonDetail,
        "app-personfrom": PersonFrom,
        "app-article": Article,
        "app-articledetail": ArticleDetail,
        "app-articlefrom": ArticleFrom,
    },
})