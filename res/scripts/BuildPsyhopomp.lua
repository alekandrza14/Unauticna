-- defines a Jump function
function Build (patrn)
for i=-6,6,1 do
for j=-6,6,1 do


        vec3.Add(i);
        vec3.Add(2);
        vec3.Add(j);
   
end
end
for i=-8,8,1 do
for j=-8,8,1 do


        vec3.Add(math.random(-200,200));
        vec3.Add(math.random(-200,200));
        vec3.Add(math.random(-200,200));
   
end
end
for i=-2,2,1 do
for j=-2,2,1 do


        vec3.Add(math.random(-200,200));
        vec3.Add(math.random(-200,200));
        vec3.Add(math.random(-200,200));
   
end
end

return vec3;
end


function Item (patrn)

for i=-6,6,1 do
for j=-6,6,1 do

ditem.Add("пена");
   
end
end
for i=-8,8,1 do
for j=-8,8,1 do

ditem.Add("RedColour");

end
end
for i=-2,2,1 do
for j=-2,2,1 do

ditem.Add("Мерисью");

end
end

return ditem;
end