var $url = '/restriction/range/';

var data = utils.init({
  isWhiteList: utils.getQueryBoolean('isWhiteList'),
  ranges: null
});

var methods = {
  apiGet: function () {
    var $this = this;

    utils.loading(this, true);
    $api.get($url, {
      params: {
        isWhiteList: this.isWhiteList
      }
    }).then(function (response) {
      var res = response.data;

      $this.ranges = res.ranges;
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  apiDelete: function(rangeId) {
    var $this = this;

    utils.loading(this, true);
    $api.delete($url, {
      data: {
        isWhiteList: this.isWhiteList,
        rangeId: rangeId
      }
    }).then(function (response) {
      var res = response.data;

      $this.ranges = res.value;
      utils.success('IP访问规则删除成功');
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  btnAddClick: function() {
    utils.openLayer({
      title: '添加IP访问规则',
      url: utils.getPageUrl('restriction', 'rangeLayerAdd', {
        isWhiteList: this.isWhiteList
      })
    })
  },

  btnEditClick: function(range) {
    utils.openLayer({
      title: '添加IP访问规则',
      url: utils.getPageUrl('restriction', 'rangeLayerAdd', {
        isWhiteList: this.isWhiteList,
        rangeId: range.id,
        ipRange: range.ipRange
      })
    })
  },

  btnDeleteClick: function(range) {
    var $this = this;
    utils.alertDelete({
      title: '删除IP访问规则',
      text: 'IP访问规则：' + range.ipRange,
      callback: function() {
        $this.apiDelete(range.id);
      }
    })
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
