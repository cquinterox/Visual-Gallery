// Cesar F Quinteros 2009
// http://www.quinterox.com

    var init = new function() {  
    // Set some global variables      
        this.stage = document.getElementById('img_stage');
        this.container = document.getElementById('container');     
                
    // Redo all links
        this.ul_images = document.getElementById('ul_images');
        this.ul_image_li_anchors = this.ul_images.getElementsByTagName('a');
        for (var x = 0; x < this.ul_image_li_anchors.length; x++)
        {
            this.ul_image_li_anchors[x].setAttribute('href', '#');
        } 
        
   // Clear the stage area
    this.clearStage = function() {
        init.container.className = ''; 
        while (init.stage.childNodes.length > 0) {
            init.stage.removeChild(init.stage.firstChild);  
        }   
    };
    // Show the larger image of the small
    this.showImage = function(url) {   
        init.container.className = 'hide'; 
        this.stageImage = document.createElement('img');        
        this.stageImage.setAttribute('src', url);
        this.stageImage.setAttribute('alt','Click to close');   
        this.stageImage.onclick = init.clearStage;
        init.stage.appendChild(this.stageImage);
    };
    // Combat explorer memory leaks
    this.cleanUp = function() {
        init.stage = null;
        init.container = null;
        init.stageImage = null;
    };    
    }