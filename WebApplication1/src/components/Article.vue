<template>
    <div id="article">
        <!--顯示文章資料庫細項-->
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Header</th>
                    <th scope="col">Author</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(item, name) in articles" v-if="(name < pageIndex) && (name >= (pageIndex-5))">
                    <td scope="row">{{ item.n.id}}</td>
                    <!--<td scope="row"><button id="changeUrl" @click.prevent="changeUrl">{{ item['n'].header}}</button></td>-->
                    <td scope="row"><a v-bind:href="'/article/detail/'+item.n.id" class="test btn btn-primary">{{ item['n'].header}}</a></td>
                    <td scope="row">{{ item.m.name}}</td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td>Sum</td>
                    <td>$180</td>
                </tr>
            </tfoot>
        </table>
        <!--頁碼功能-->
        <div>
            <a href="/article" @click.prevent=" upPage()"><</a>
            <a href="/article" v-bind:id="'pageindex'+articlesLength" v-for="articlesLength in articlesLengths" @click.prevent=" changePage(articlesLength)">
                {{ articlesLength}}<span if="articlesLength != (articlesLength-1)">/</span>
            </a>

            <a href="/article" @click.prevent=" downPage()">></a>
        </div>
    </div>
</template>

<script>

export default {
  data () {
    return {
        //articles: [],
        //id: null,
        articlesLengths: 1,
        pageStaute:1,
        pageIndex:5
    }
  },
  methods: {      
      //觀看內容轉址
      /*
      changeUrl(event) {
          console.log(event.target);
          var changeUrl = event.target.innerHTML; 
          console.log(changeUrl);
          for (var item in this.$store.state.articles) {     
              console.log(this.$store.state.articles[item].n.header);
              if (changeUrl === this.$store.state.articles[item].n.header) {                  
                  console.log(this.$store.state.articles[item].n.header);
                  this.$store.commit('updateArticlesId', this.$store.state.articles[item].n.id);
                  console.log(this.$store.state.articles[item].n.id);
                  console.log(this.$store.state.ArticlesId);
                  //document.location.href = "/article/detail/" + this.$store.state.ArticlesId;
                  break;                  
              } else {
                  console.log("bad.....");
              }
          }
      },*/
      //選擇頁數
      changePage(nowPageIndex) {
          this.pageStaute = nowPageIndex;
          this.pageInexChange();
      },
      //上一頁
      downPage() {
          if (this.pageStaute === this.articlesLengths) {
              this.pageStaute = this.articlesLengths;
          } else {
              this.pageStaute += 1;
          }  
          this.pageInexChange();
      },
      //下一頁
      upPage() {
          if (this.pageStaute === 1) {
              this.pageStaute = 1;
          } else {
              this.pageStaute -= 1;
          }
          this.pageInexChange();
      },
      //直跳頁面
      pageInexChange() {
          this.pageIndex = 5;
          if (this.pageIndex !== this.articlesLengths * 5) {
              this.pageIndex += (this.pageStaute - 1) * 5;
          } else {
              this.pageIndex = this.articlesLengths * 5;
          }
      }
  },
        created() {
            //從Vuex 抓取API資料
            this.$store.dispatch('getArticleapi')
                .then((result) => {
                    //將API資料存至articles陣列中
                    this.$store.state.articles = result.data;
                    //計算資料長度
                    //以5的倍數紀錄頁碼
                    this.articlesLengths = this.$store.state.articles.length;
                    if ((this.articlesLengths / 5) === 0) {
                        this.articlesLengths = (this.articlesLengths / 5);
                    } else {
                        this.articlesLengths = Math.ceil(this.articlesLengths / 5);

                    }
                   //console.log(this.articlesLengths);
                   //console.log(data.data);
                    //console.table(result.data);
                })
                .catch((err) => { console.error(err) });
            /*
            //ajax axios抓取api資料
            const api = 'https://localhost:44377/api/articleapi';
            this.$http.get(api)
                .then((data) => {
                    //將API資料存至articles陣列中
                    this.articles = data.data;
                    //計算資料長度
                    //以5的倍數紀錄頁碼
                    this.articlesLengths = this.articles.length;
                    if ((this.articlesLengths / 5) === 0) {
                        this.articlesLengths = (this.articlesLengths / 5);
                    } else {
                        this.articlesLengths = Math.ceil(this.articlesLengths / 5);

                    }
                   //console.log(this.articlesLengths);
                   //console.log(data.data);
                })
                .catch(function (error) {
                    console.log(error);
                });*/
        
        },
        computed: {
            //抓取articles相關資料
            articles() {
                return this.$store.state.articles;
            }
        }
   }
</script>

<style>

</style>
