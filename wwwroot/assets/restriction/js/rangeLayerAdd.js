var $url = 'restriction/rangeLayerAdd';

var data = utils.init({
  isAllowList: utils.getQueryBoolean('isAllowList'),
  range: utils.getQueryString('range'),
  ipAddress: null,
  form: {
    range: utils.getQueryString('range')
  }
});

var methods = {
  apiGet: function () {
    var $this = this;

    utils.loading(this, true);
    $api.get($url).then(function (response) {
      var res = response.data;

      $this.ipAddress = res.value;
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  apiAdd: function () {
    var $this = this;

    utils.loading(this, true);
    $api.post($url, {
      isAllowList: this.isAllowList,
      range: this.form.range
    }).then(function (response) {
      setTimeout(function() {
        parent.$vue.apiGet();
        utils.success('设置保存成功');
        utils.closeLayer();
      }, 30000);
    }).catch(function (error) {
      utils.error(error);
    });
  },

  apiEdit: function () {
    var $this = this;

    utils.loading(this, true);
    $api.put($url, {
      isAllowList: this.isAllowList,
      oldRange: this.range,
      newRange: this.form.range
    }).then(function (response) {
      setTimeout(function() {
        parent.$vue.apiGet();
        utils.success('设置保存成功');
        utils.closeLayer();
      }, 30000);
    }).catch(function (error) {
      utils.error(error);
    });
  },

  btnSubmitClick: function () {
    var $this = this;
    this.$refs.form.validate(function(valid) {
      if (valid) {
        if ($this.range) {
          $this.apiEdit();
        } else {
          $this.apiAdd();
        }
      }
    });
  },

  btnCancelClick: function () {
    utils.closeLayer();
  }
};

var $vue = new Vue({
  el: "#main",
  data: data,
  methods: methods,
  created: function () {
    this.apiGet();
  }
});
