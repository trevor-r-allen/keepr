<template>
  <div class="masonry-item" data-toggle="modal" :data-target="'#keepModal'+keepProp.id">
    <div class="keepComponent card">
      <img class="keepImg card-img-top img-fluid" :src="keepProp.img" alt="">
      <h4 class="keepName card-title text-light" style="position: absolute;">
        {{ keepProp.name }}
      </h4>
      <router-link :to="{name: 'Profile', params: {id: keepProp.creatorId}}">
        <img class="creatorPic img-fluid" :src="keepProp.creator.picture" alt="">
      </router-link>
    </div>
    <keep-modal-component :key="keepProp.id" :keep-prop="keepProp" />
  </div>
</template>

<script>
import { reactive } from 'vue'
import KeepModalComponent from './KeepModalComponent.vue'
export default {
  components: { KeepModalComponent },
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
