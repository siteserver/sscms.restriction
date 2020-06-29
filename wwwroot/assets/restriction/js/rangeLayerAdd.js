var $url = 'restriction/rangeLayerAdd';

var data = utils.init({
  isWhiteList: utils.getQueryBoolean('isWhiteList'),
  rangeId: utils.getQueryInt('rangeId'),
  ipAddress: null,
  form: {
    ipRange: utils.getQueryString('ipRange')
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
      isWhiteList: this.isWhiteList,
      ipRange: this.form.ipRange
    }).then(function (response) {
      parent.$vue.apiGet();
      utils.success('设置保存成功');
      utils.closeLayer();
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  apiEdit: function () {
    var $this = this;

    utils.loading(this, true);
    $api.put($url, {
      isWhiteList: this.isWhiteList,
      rangeId: this.rangeId,
      ipRange: this.form.ipRange
    }).then(function (response) {
      parent.$vue.apiGet();
      utils.success('设置保存成功');
      utils.closeLayer();
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  btnSubmitClick: function () {
    var $this = this;
    this.$refs.form.validate(function(valid) {
      if (valid) {
        if ($this.rangeId) {
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
