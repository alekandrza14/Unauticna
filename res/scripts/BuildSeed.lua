-- defines a Jump function
function Build (patrn)
for i=1,3,1 do


        vec3.Add(math.random(-6,6));
        vec3.Add(1);
        vec3.Add(math.random(-6,6));
   
end

return vec3;
end


function Item (patrn)

for i=1,3,1 do


ditem.Add("seed");
   
end


return ditem;
end