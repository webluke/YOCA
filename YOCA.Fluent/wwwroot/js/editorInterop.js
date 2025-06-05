window.toastuiBlazor = {
    editor: null,
    create: function (elementId, initialValue) {
        const Editor = toastui.Editor;
        const codeSyntaxHighlight = toastui.Editor.plugin.codeSyntaxHighlight;
        const hljs = window.hljs;

        this.editor = new Editor({
            el: document.getElementById(elementId),
            height: '400px',
            initialEditType: 'wysiwyg',
            previewStyle: 'tab',
            initialValue: initialValue || '',
            theme: 'dark',
            plugins: [[codeSyntaxHighlight, { highlighter: hljs }]],
        });
    },
    getMarkdown: function () {
        return this.editor ? this.editor.getMarkdown() : '';
    },
    setMarkdown: function (value) {
        if (this.editor) {
            this.editor.setMarkdown(value || '');
        }
    },
    destroy: function () {
        if (this.editor) {
            this.editor.destroy();
            this.editor = null;
        }
    }
};