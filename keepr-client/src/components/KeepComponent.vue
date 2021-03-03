<template>
  <div class="masonry-item">
    <div class="keepComponent card">
      <img class="keepImg card-img-top img-fluid" :src="keepProp.img" alt="">
      <h4 class="keepName card-title text-light " style="position: absolute;">
        {{ keepProp.name }}
      </h4>
      <router-link :to="{name: 'Profile', params: {id: keepProp.creatorId}}">
        <img class="creatorPic img-fluid" :src="keepProp.creator.picture" alt="">
      </router-link>
    </div>
  </div>
</template>

<script>
import { reactive } from 'vue'
export default {
  name: 'KeepComponent',
  props: {
    keepProp: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const state = reactive({

    })
    return {
      state
    }
  }
}
</script>

<style lang="scss" scoped>
.masonry-item{
  display: inline-block;
  margin: 0 0 1em;
  width: 100%;

}
.keepComponent{
position: relative;
border-radius: 10px;
}
.keepImg{
border-radius: 10px;
mask-image: linear-gradient(180.45deg, rgba(0, 0, 0, 0) 80%, rgba(0, 0, 0, 0.53) 99);
-webkit-mask-image: linear-gradient(180.45deg, rgba(0, 0, 0, 0) 80%, rgba(0, 0, 0, 0.53) 99);
}
.keepName{
  position: absolute;
  bottom: 8px;
  left: 16px;
}
.creatorPic{
  box-shadow: 100px 100px 1000px rgba(0, 0, 0, 0);
  position: absolute;
  border-radius: 50%;
  bottom: 8px;
  right: 16px;
  max-height: 50px;
  max-width: 50px;
}
</style>
